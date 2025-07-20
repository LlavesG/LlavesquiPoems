
using LlavesquiPoems.Application.Interfaces.IRepositories;
using LlavesquiPoems.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace LlavesquiPoems.Infrastructure.Repositories;

public class RecitalRepository : IRecitalRepository
{
    private readonly ApplicationDbContext _context;

    public RecitalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Recital>> GetNextAsync()
    {
        return await _context.Recitals.AsNoTracking()
            .Where(r => r.Date >= DateTime.UtcNow.Date)
            .OrderBy(r => r.Date)
            .ToListAsync();
    }

    public async Task<Recital> AddAsync(Recital recital)
    {
        var recitalBd =await _context.Recitals.AddAsync(recital);
        await _context.SaveChangesAsync();
        return recitalBd.Entity;
    }

    public async Task<Recital?> GetByIdAsync(int id)
    {
        return await _context.Recitals.FindAsync(id);
    }

    public async Task UpdateAsync(Recital recital)
    {
        _context.Recitals.Update(recital);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var recital = await _context.Recitals.FindAsync(id);
        if (recital != null)
        {
            _context.Recitals.Remove(recital);
            await _context.SaveChangesAsync();
        }
    }
}