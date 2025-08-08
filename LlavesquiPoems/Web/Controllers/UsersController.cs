using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;

namespace LlavesquiPoems.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUsersService usersService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserDto>> Get(int id)
    {
        var user = await usersService.GetAsync(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetList()
    {
        var user = await usersService.GetListAsync();
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Insert(UserDto user)
    {
        var created = await usersService.InsertAsync(user);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut()]
    public async Task<IActionResult> Update(UserDto user)
    {
        await usersService.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await usersService.DeleteAsync(id);
        return NoContent();
    }
}