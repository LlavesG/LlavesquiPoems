using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LlavesquiPoems.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService): ControllerBase
{
    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>>  Login([FromBody] LoginDto dto)
    {
        var user = await authService.LoginAsync(dto);
        return Ok(user) ;
             
    }

    [HttpPost("SignIn")]
    public async Task<ActionResult<UserDto>>  SignIn([FromBody] UserDto dto)
    {
        var user = await authService.SignInAsync(dto);
        return Ok(user) ;
    }
}