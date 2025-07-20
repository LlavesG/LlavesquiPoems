using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Interfaces.IService;

public interface IProductService
{
    Task<ProductDto?> GetAsync(int id);
    Task<IEnumerable<ProductDto>> GetListAsync();
    Task<ProductDto> InsertAsync(ProductDto product);
    Task UpdateAsync(ProductDto product);
    Task DeleteAsync(int id);
}