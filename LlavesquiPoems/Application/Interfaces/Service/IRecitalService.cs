using System.Collections.Generic;
using System.Threading.Tasks;
using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Interfaces.IService;

public interface IRecitalService
{
    Task<IEnumerable<RecitalDto>> GetUpcomingRecitalsAsync();
    Task<RecitalDto> AddAsync(RecitalDto dto);
    Task UpdateAsync(RecitalDto dto);
    Task DeleteAsync(int id);
}