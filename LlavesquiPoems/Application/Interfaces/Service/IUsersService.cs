using LlavesquiPoems.Application.Dtos;

namespace LlavesquiPoems.Application.Interfaces.IService;

public interface IUsersService
{
    Task<UserDto?> GetAsync(int id);
    Task<IEnumerable<UserDto>> GetListAsync();
    Task<UserDto> InsertAsync(UserDto product);
    Task UpdateAsync(UserDto product);
    Task DeleteAsync(int id);
}