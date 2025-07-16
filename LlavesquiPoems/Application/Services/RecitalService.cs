using LlavesquiPoems.Application.Interfaces;
using LlavesquiPoems.Application.Interfaces.IRepositories;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Services;

public class RecitalService : IRecitalService
{
    private readonly IRecitalRepository _repo;

    public RecitalService(IRecitalRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Recital>> GetUpcomingRecitalsAsync()
    {
        return await _repo.GetNextAsync();
    }
}