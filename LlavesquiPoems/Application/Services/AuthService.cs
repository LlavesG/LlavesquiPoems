using System.Linq.Expressions;
using System.Net.Mail;
using LlavesquiPoems.Application.Configurations;
using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Helpers;
using LlavesquiPoems.Application.Interfaces.Factories;
using LlavesquiPoems.Application.Interfaces.IRepository;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Interfaces.Validations.Exceptions;
using LlavesquiPoems.Application.Mappers;
using LlavesquiPoems.Application.Services.Factories.Users;
using LlavesquiPoems.Domain.Entities;
using Microsoft.Extensions.Options;

namespace LlavesquiPoems.Application.Services;

public class AuthService(
    IGenericRepository<User> userRepository,
    IOptions<EncodeConfiguration> options,
    IOptions<SmtpConfiguration> smtpOptions)
    : IAuthService
{
    private readonly TokenHelper _tokenHelper = new(options.Value);
    private readonly EncripterHelper _encripter = new(options.Value);
    private readonly SmtpHelper _smtp = new(smtpOptions.Value);
    private readonly IEmailFactory _emailFactory = new EmailCreatedFactory();

    public async Task<UserDto> LoginAsync(LoginDto dto)
    {
        dto.Password = _encripter.EncryptStringToBytes_Aes(dto.Password);
        var user =(await userRepository.GetAsync(x=> (x.UserName == dto.UserName||x.Email== dto.UserName)&&
                                                       (x.Password == dto.Password)));
        if (user == null)
        {
            throw new UserNotFoundException("Invalid Credentials");
            return null;
        }
        var userLoged = Mapper.UserMapper.ToDto(user);
        userLoged = _tokenHelper.GetUserWithToken(userLoged);
        
        return userLoged;
    }
    public async Task<UserDto> SignInAsync(UserDto dto)
    {
        dto.CreatedAt = DateTime.UtcNow;
        UserDto newUser;
        dto.Password = _encripter.EncryptStringToBytes_Aes(dto.Password);
        
        userRepository.BegingTransaction();

        if (userRepository.Exists(x=> x.UserName == dto.UserName || x.Email == dto.Email))
        {
            throw new UserAlreadyExistsException("User Already Exists");
        }
        try{
            var user = Mapper.UserMapper.ToEntity(dto);
            user = await userRepository.AddAsync(user);
            newUser = Mapper.UserMapper.ToDto(user);
            newUser = _tokenHelper.GetUserWithToken(newUser);
        }catch(Exception ex)
        {
            userRepository.RollbackTransaction();
            throw new Exception("Error inserting user", ex);
        }
        await _smtp.SendEmail(_emailFactory.CreateUser(newUser));
        userRepository.SaveChanges();

        return newUser;
    }
}