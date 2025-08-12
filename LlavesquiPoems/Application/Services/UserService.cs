using System.Net.Mail;
using LlavesquiPoems.Application.Configurations;
using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Helpers;
using LlavesquiPoems.Application.Interfaces.IRepository;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Interfaces.Repositories;
using LlavesquiPoems.Application.Mappers;
using LlavesquiPoems.Application.Models;
using LlavesquiPoems.Domain.Entities;
using LlavesquiPoems.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LlavesquiPoems.Application.Services;

public class UserService : IUsersService
{
    private readonly IGenericRepository<User> _basicRepository;
    private readonly IUserRepository _userRepository;
    private readonly EncripterHelper _encripter;
    private readonly SmtpHelper _smtp;
    private readonly TokenHelper _tokenHelper;
    public UserService(IGenericRepository<User> basicRepository,IUserRepository userRepository, IOptions<EncodeConfiguration> options, IOptions<SmtpConfiguration> smtpOptions)
    {
        _encripter = new EncripterHelper(options.Value);
        _smtp = new SmtpHelper(smtpOptions.Value);
        _tokenHelper = new TokenHelper(options.Value);
        _basicRepository = basicRepository;
        _userRepository = userRepository;
    }

    public async Task<UserDto?> GetAsync(int id)
    {
        var user = await _basicRepository.GetByIdAsync(id);
        return user == null ? null : Mapper.UserMapper.ToDto(user);
    }
    
    public async Task<UserProfileDto?> GetBySessionAsync(object? session)
    {
        Session sessionObj = (Session)session!;
        var user = await _basicRepository.GetByIdAsync(sessionObj.Id);
        var result = new UserProfileDto
        {
            BasicData = Mapper.UserMapper.ToDto(user),
            Orders = await _userRepository.GetOrdersByUserId(user.Id),
            Rewards = await _userRepository.GetRewardsByUserId(user.Id)
        };
        return result;
    }
    
    public async Task<IEnumerable<UserDto>> GetListAsync()
    {
        var users = await _basicRepository.GetAllAsync();
        return users.Select(Mapper.UserMapper.ToDto);
    }

    public async Task<UserDto> InsertAsync(UserDto dto)
    {

        dto.CreatedAt = DateTime.UtcNow;
        UserDto newUser;
        MailMessage email;
        dto.Password = _encripter.EncryptStringToBytes_Aes(dto.Password);
        
        _basicRepository.BegingTransaction();

        if (ChecExistUser(dto))
        {
            throw new Exception("User already exists");
        }
        try{
        var user = Mapper.UserMapper.ToEntity(dto);
        user = await _basicRepository.AddAsync(user);
        newUser = Mapper.UserMapper.ToDto(user);
        newUser = _tokenHelper.GetUserWithToken(newUser);
         email = _smtp.CreateEmailValdate(newUser, newUser.Token);
        }catch(Exception ex)
        {
            _basicRepository.RollbackTransaction();
            throw new Exception("Error inserting user", ex);
        }
        await _smtp.SendEmail(email);
        _basicRepository.SaveChanges();

        return newUser;
    }

    public async Task UpdateAsync(UserDto user)
    {
        if (string.IsNullOrEmpty(user.Password)) 
        {
            var userBd =await _basicRepository.GetByIdAsync(user.Id);
            user.Password = userBd.Password;
        }
        else
        {   
            user.Password = _encripter.EncryptStringToBytes_Aes(user.Password);
        }
        await _basicRepository.UpdateAsync(Mapper.UserMapper.ToEntity(user));
    }

    public async Task DeleteAsync(int id)
    {
        await _basicRepository.DeleteAsync(id);
    }
    
    public async Task<ContentResult> ValidateUser(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentException("Token cannot be null or empty", nameof(token));
        }

        var session = _tokenHelper.GetSesion(token);
        if (session == null)
        {
            throw new ArgumentException("Invalid token format", nameof(token));
        }

        var user = await _basicRepository.GetByIdAsync(session.Id);
        user.Active = true;
        await _basicRepository.UpdateAsync(user);
        var response = new ContentResult();
        var newUser = Mapper.UserMapper.ToDto(user);
        newUser = _tokenHelper.GetUserWithToken(newUser);
        var email = _smtp.CreateEmailValdate(newUser, newUser.Token);
        await _smtp.SendEmail(email);
        return new ContentResult
        {
            ContentType = "text/html",
            Content = HtmlHelper.GetHtmlVerificado(newUser)
        };

    }

    private  bool ChecExistUser(UserDto user)
    {
        return  _basicRepository.Exists(x => x.Email.ToUpper() == user.Email.ToUpper() || x.UserName.ToUpper() == user.UserName.ToUpper());
    }

}