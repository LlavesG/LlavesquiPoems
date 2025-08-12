using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LlavesquiPoems.Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LlavesquiPoems.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> :IGenericRepository<TEntity> where TEntity : class 
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public virtual void BegingTransaction()
        { 
            _context.Database.BeginTransaction();
        }
        public virtual void SaveChanges()
        { 
            _context.Database.CommitTransaction();
        }
        public virtual void RollbackTransaction()
        { 
            _context.Database.RollbackTransaction();
        }
        public bool Exists(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Any(where);
        }
        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.FirstOrDefaultAsync(where);
        }
        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return _dbSet.Count(where);
        }


    }
}