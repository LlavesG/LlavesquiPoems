using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Interfaces.IRepository;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Mappers;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Services;

public class UserService : IUsersService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
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

    public async Task<UserDto> InsertAsync(UserDto user)
    {
        user.CreatedAt= DateTime.UtcNow;
        var userEntity =await _userRepository.AddAsync(Mapper.UserMapper.ToEntity(user));
        return Mapper.UserMapper.ToDto(userEntity);
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