using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Interfaces.Repositories;
using LlavesquiPoems.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LlavesquiPoems.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Task<List<OrderDto>> GetOrdersByUserId(int userId)
    {
        return (from or in _context.Orders.AsNoTracking()
                join pr in _context.Products.AsNoTracking() on or.IdProduct equals pr.Id
                join re in _context.Recitals.AsNoTracking() on or.IdRecital equals re.Id into reEmpty
                from re in reEmpty.DefaultIfEmpty()
                where or.IdUser == userId
                select new OrderDto
                {
                    Id = or.Id,
                    IdProduct = or.IdProduct,
                    IdRecital = or.IdRecital,
                    Price = or.Price,
                    State = or.State,
                    ProductName = pr.Name,
                    RecitalDate = re!= null ? re.Date : null,
                    RecitalName = re!= null ?re.Name:null,
                    CreatedAt = or.CreatedAt,
                    UpdatedAt = or.UpdatedAt,
                }).ToListAsync();
    }
    public Task<List<RewardDto>> GetRewardsByUserId(int userId)
    {
        var query = (from rw in _context.Rewards.AsNoTracking()
            join pr in _context.Products.AsNoTracking() on rw.IdProduct equals pr.Id
            where rw.IdUser == userId
            select new RewardDto
            {
                Id = rw.Id,
                IdProduct = rw.IdProduct,
               State = rw.State,
                CreatedAt = rw.CreatedAt,
                UpdatedAt = rw.UpdatedAt,
                Description = rw.Description,
                Name = pr.Name
                
            });
        return query.ToListAsync();
    }
}