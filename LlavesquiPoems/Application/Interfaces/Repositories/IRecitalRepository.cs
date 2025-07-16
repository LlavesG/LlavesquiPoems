using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Interfaces.IRepositories;

public interface  IRecitalRepository
{
    Task<IEnumerable<Recital>> GetNextAsync();
}