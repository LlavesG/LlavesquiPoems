using LlavesquiPoems.Application.Helpers;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace LlavesquiPoems.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValidationController(IUsersService usersService) : Controller
{

    [HttpGet()]
    public async Task<ContentResult> Validate([FromQuery] string a)
    {
        return await usersService.ValidateUser(a);
    }
}