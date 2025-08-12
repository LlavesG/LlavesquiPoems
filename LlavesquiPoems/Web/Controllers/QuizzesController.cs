using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Models.Dtos;
using LlavesquiPoems.Web.Midelwares;
using Microsoft.AspNetCore.Mvc;

namespace LlavesquiPoems.Web.Controllers;


[ApiController]
[ValidateLogin]
[Route("api/[controller]")]
public class QuizzesController(IQuizzesService quizzesService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<QuizDto>> Get(int id)
    {
        var product = await quizzesService.GetByIdAsync(id);
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<QuizDto>>> GetList()
    {
        var products = await quizzesService.GetListAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<QuizDto>> Insert(QuizDto product)
    {
        var created = await quizzesService.InsertAsync(product);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut()]
    public async Task<IActionResult> Update( QuizDto product)
    {
        await quizzesService.UpdateAsync(product);
        return NoContent();
    }

}