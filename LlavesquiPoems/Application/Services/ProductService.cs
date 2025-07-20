using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Interfaces.IRepository;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Mappers;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Services;

public class ProductService : IProductService
{
    private readonly IGenericRepository<Product> _productRepository;

    public ProductService(IGenericRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto?> GetAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        return product == null ? null : Mapper.ProductMapper.ToDto(product);
    }

    public async Task<IEnumerable<ProductDto>> GetListAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(Mapper.ProductMapper.ToDto);
    }

    public async Task<ProductDto> InsertAsync(ProductDto product)
    {
        product.CreatedAt= DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;
        var productEntity =await _productRepository.AddAsync(Mapper.ProductMapper.ToEntity(product));
        return Mapper.ProductMapper.ToDto(productEntity);
    }

    public async Task UpdateAsync(ProductDto product)
    {
        product.UpdatedAt = DateTime.UtcNow;
        await _productRepository.UpdateAsync(Mapper.ProductMapper.ToEntity(product));
    }

    public async Task DeleteAsync(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}