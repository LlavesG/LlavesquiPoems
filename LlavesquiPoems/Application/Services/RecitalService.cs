using System.Collections.Generic;
using System.Threading.Tasks;
using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Interfaces;
using LlavesquiPoems.Application.Interfaces.IRepositories;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Mappers;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Services;

public class RecitalService : IRecitalService
{
    private readonly IRecitalRepository _repo;

    public RecitalService(IRecitalRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<RecitalDto>> GetUpcomingRecitalsAsync()
    {
        var recitals = await _repo.GetNextAsync();
        return recitals.Select(Mapper.RecitalMapper.ToDto) ;
    }
    public async Task<RecitalDto> AddAsync(RecitalDto dto)
    {
        var recital =await _repo.AddAsync(Mapper.RecitalMapper.ToEntity(dto));
        return Mapper.RecitalMapper.ToDto(recital);
    }

    public async Task UpdateAsync(RecitalDto dto)
    {
        await _repo.UpdateAsync(Mapper.RecitalMapper.ToEntity(dto));
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}