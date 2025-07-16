using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LlavesquiPoems.Application.Interfaces;
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
}