using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Models;
using LlavesquiPoems.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LlavesquiPoems.Application.Interfaces.IService;

public interface IUsersService
{
    Task<UserDto?> GetAsync(int id);
    Task<UserProfileDto?> GetBySessionAsync(object? session);
    Task<IEnumerable<UserDto>> GetListAsync();
    Task<UserDto> InsertAsync(UserDto dto);
    Task UpdateAsync(UserDto product);
    Task DeleteAsync(int id);
    Task<ContentResult> ValidateUser(string token);
}