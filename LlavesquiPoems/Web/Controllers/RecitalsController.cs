using System.Linq;
using System.Threading.Tasks;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace LlavesquiPoems.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecitalsController: ControllerBase
{
    private readonly IRecitalService _recitalService;

    public RecitalsController(IRecitalService recitalService)
    {
        _recitalService = recitalService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUpcomingRecitals()
    {
        var recitales = await _recitalService.GetUpcomingRecitalsAsync();
        var recitalDtos = recitales.Select(Mapper.RecitalMapper.ToDto);
        return Ok(recitalDtos);
    }
}