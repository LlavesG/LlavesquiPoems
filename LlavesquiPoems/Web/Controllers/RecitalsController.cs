using System.Linq;
using System.Threading.Tasks;
using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Interfaces.IService;
using LlavesquiPoems.Application.Mappers;
using LlavesquiPoems.Domain.Entities;
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
        return Ok(recitales);
    }
    [HttpPost]
    public async Task<IActionResult> CreateRecital([FromBody] RecitalDto dto)
    {
        var recitales = await _recitalService.AddAsync(dto);
        return Ok(recitales);
        
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateRecital([FromBody] RecitalDto dto)
    {
         await _recitalService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecital(int id)
    {
        await _recitalService.DeleteAsync(id);
        return Ok();
    }
}