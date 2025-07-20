using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Domain.Entities;

namespace LlavesquiPoems.Application.Mappers;

public class Mapper
{
    public static class RecitalMapper
    {
        public static RecitalDto ToDto(Recital r) => new()
        {
            Id = r.Id,
            City = r.City,
            Date = r.Date,
            Venue = r.Venue,
            Address = r.Address,
            CreatedAt = r.CreatedAt,
            UpdatedBy = r.UpdatedBy,
            CreatedBy = r.CreatedBy,
            UpdatedAt = r.UpdatedAt
        };
        public static Recital ToEntity(RecitalDto r) => new()
        {
            Id = r.Id,
            City = r.City,
            Date = r.Date,
            Venue = r.Venue,
            Address = r.Address,
            CreatedAt = r.CreatedAt,
            UpdatedBy = r.UpdatedBy,
            CreatedBy = r.CreatedBy,
            UpdatedAt = r.UpdatedAt
        };
    }
}