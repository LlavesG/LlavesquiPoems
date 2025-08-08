using System.Net.Mail;
using LlavesquiPoems.Application.Configurations;
using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Helpers;
using LlavesquiPoems.Application.Interfaces.IRepository;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Mappers;
using LlavesquiPoems.Domain.Entities;
using LlavesquiPoems.Infrastructure.Repositories;
using Microsoft.Extensions.Options;

namespace LlavesquiPoems.Application.Services;

public class UserService : IUsersService
{
    private readonly IGenericRepository<User> _userRepository;
    private readonly EncripterHelper _encripter;
    private readonly SmtpHelper _smtp;
    private readonly TokenHelper _tokenHelper;
    public UserService(IGenericRepository<User> userRepository,IOptions<EncodeConfiguration> options, IOptions<SmtpConfiguration> smtpOptions)
    {
        _encripter = new EncripterHelper(options.Value);
        _smtp = new SmtpHelper(smtpOptions.Value);
        _tokenHelper = new TokenHelper(options.Value);
        _userRepository = userRepository;
    }

    public async Task<UserDto?> GetAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user == null ? null : Mapper.UserMapper.ToDto(user);
    }

    public async Task<IEnumerable<UserDto>> GetListAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(Mapper.UserMapper.ToDto);
    }

    public async Task<UserDto> InsertAsync(UserDto dto)
    {

        dto.CreatedAt = DateTime.UtcNow;
        UserDto newUser = new UserDto();
        var email = new MailMessage();
        dto.Password = _encripter.EncryptStringToBytes_Aes(dto.Password);
        
        _userRepository.BegingTransaction();
       
        try{
        User user = Mapper.UserMapper.ToEntity(dto);
        user = await _userRepository.AddAsync(user);
         newUser = Mapper.UserMapper.ToDto(user);
        newUser = _tokenHelper.GetUserWithToken(newUser);
         email = _smtp.CreateEmailValdate(newUser, newUser.Token);
        }catch(Exception ex)
        {
            _userRepository.RollbackTransaction();
            throw new Exception("Error inserting user", ex);
        }
        await _smtp.SendEmail(email);
        _userRepository.SaveChanges();

        return newUser;
    }

    public async Task UpdateAsync(UserDto user)
    {
        await _userRepository.UpdateAsync(Mapper.UserMapper.ToEntity(user));
    }

    public async Task DeleteAsync(int id)
    {
        await _userRepository.DeleteAsync(id);
    }
}