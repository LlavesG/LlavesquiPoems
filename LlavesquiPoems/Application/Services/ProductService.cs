using LlavesquiPoems.Application.Interfaces.IRepository;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Services;

public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _productRepository;

    public ProductService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetListAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> InsertAsync(Product product)
    {
        product.CreatedAt= DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;
        return await _productRepository.AddAsync(product);
    }

    public async Task UpdateAsync(Product product)
    {
        product.UpdatedAt = DateTime.UtcNow;
        await _productRepository.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}