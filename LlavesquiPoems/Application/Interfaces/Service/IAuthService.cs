using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Interfaces.IService;

public interface IAuthService
{
    Task<UserDto> LoginAsync(LoginDto dto);
    Task<UserDto> SignInAsync(UserDto dto);
}