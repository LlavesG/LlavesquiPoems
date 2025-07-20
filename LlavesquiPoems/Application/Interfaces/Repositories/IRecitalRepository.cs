using System.Collections.Generic;
using System.Threading.Tasks;
using LlavesquiPoems.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LlavesquiPoems.Application.Interfaces.IRepositories;

public interface  IRecitalRepository
{
    Task<IEnumerable<Recital>> GetNextAsync();
    Task DeleteAsync(int id);
    Task UpdateAsync(Recital recital);
    Task<Recital?> GetByIdAsync(int id);
    Task<Recital> AddAsync(Recital recital);
}