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
public class RecitalsController(IRecitalService recitalService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUpcomingRecitals()
    {
        var recitales = await recitalService.GetUpcomingRecitalsAsync();
        return Ok(recitales);
    }
    [HttpPost]
    public async Task<IActionResult> CreateRecital([FromBody] RecitalDto dto)
    {
        var recitales = await recitalService.AddAsync(dto);
        return Ok(recitales);
        
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateRecital([FromBody] RecitalDto dto)
    {
         await recitalService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRecital(int id)
    {
        await recitalService.DeleteAsync(id);
        return Ok();
    }
}