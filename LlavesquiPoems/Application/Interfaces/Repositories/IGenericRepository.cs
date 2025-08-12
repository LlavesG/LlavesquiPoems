// LlavesquiPoems.Application.Interfaces.IRepository.IGenericRepository.cs
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LlavesquiPoems.Application.Interfaces.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> where);
        void BegingTransaction();
        void SaveChanges();
        void RollbackTransaction();
        bool Exists(Expression<Func<TEntity, bool>> where);
        int Count(Expression<Func<TEntity, bool>> where);

    }
}