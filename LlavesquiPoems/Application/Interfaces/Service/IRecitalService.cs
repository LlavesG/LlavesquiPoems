using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Interfaces.IService;

public interface IRecitalService
{
    Task<IEnumerable<Recital>> GetUpcomingRecitalsAsync();
}