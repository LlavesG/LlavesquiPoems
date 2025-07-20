using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Interfaces.IService;

public interface IProductService
{
    Task<Product?> GetAsync(int id);
    Task<IEnumerable<Product>> GetListAsync();
    Task<Product> InsertAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
}