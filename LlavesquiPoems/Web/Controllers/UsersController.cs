using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Mappers;
using LlavesquiPoems.Application.Models;
using LlavesquiPoems.Web.Midelwares;
using Microsoft.AspNetCore.Mvc;

namespace LlavesquiPoems.Web.Controllers;

[ApiController]
[ValidateLogin]
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
    
    [HttpGet("me")]
    public async Task<ActionResult<UserProfileDto>> GetProfile()
    {
        HttpContext.Items.TryGetValue("Session", out var sessionObj);
        var user = await usersService.GetBySessionAsync(sessionObj);
        if (user == null)
            return NotFound();
        return Ok(user);
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