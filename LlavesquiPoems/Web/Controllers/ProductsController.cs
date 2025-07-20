using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace LlavesquiPoems.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        var product = await productService.GetAsync(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetList()
    {
        var products = await productService.GetListAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Insert(ProductDto product)
    {
        var created = await productService.InsertAsync(product);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut()]
    public async Task<IActionResult> Update( ProductDto product)
    {
        await productService.UpdateAsync(product);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await productService.DeleteAsync(id);
        return NoContent();
    }
}