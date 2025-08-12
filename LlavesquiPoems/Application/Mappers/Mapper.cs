using LlavesquiPoems.Application.Dtos;
using LlavesquiPoems.Application.Models.Dtos;
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
    public static class ProductMapper
    {
        public static ProductDto ToDto(Product p) => new()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            PublicPrice = p.PublicPrice,
            ImgUrl = p.ImgUrl,
            Type = p.Type,
            Available = p.Available,
            CreatedAt = p.CreatedAt,
            UpdatedBy = p.UpdatedBy,
            CreatedBy = p.CreatedBy,
            UpdatedAt = p.UpdatedAt
        };
        public static Product ToEntity(ProductDto p) => new()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            PublicPrice = p.PublicPrice,
            ImgUrl = p.ImgUrl,
            Type = p.Type,
            Available = p.Available,
            CreatedAt = p.CreatedAt,
            UpdatedBy = p.UpdatedBy,
            CreatedBy = p.CreatedBy,
            UpdatedAt = p.UpdatedAt
        };
       
    }
    public static class UserMapper
    {
        public static UserDto ToDto(User u) => new()
        {
            Id = u.Id,
            Name = u.Name,
            LastName = u.LastName,
            Email = u.Email,
            Phone = u.Phone,
            UserName = u.UserName,
            Address = u.Address,
            Password = u.Password,
            CreatedAt = u.CreatedAt
        };
        public static User ToEntity(UserDto u) => new()
        {
            Id = u.Id,
            Name = u.Name,
            LastName = u.LastName,
            Email = u.Email,
            Phone = u.Phone,
            UserName = u.UserName,
            Address = u.Address,
            Password = u.Password,
            CreatedAt = u.CreatedAt
        };
        public static UserLogedDto ToDtoBasic(User u) => new()
        {
            Id = u.Id,
            Name = u.Name,
            LastName = u.LastName,
            Email = u.Email,
            Phone = u.Phone,
            UserName = u.UserName,
            Address = u.Address,
            CreatedAt = u.CreatedAt
        };
    }
    public static class QuizMapper
    {
        public static QuizDto ToDto(Quiz u) => new()
        {
            Id = u.Id,
            Name = u.Name,
            Description = u.Description,
            CreatedAt = u.CreatedAt,
            UpdatedBy = u.UpdatedBy,
            CreatedBy = u.CreatedBy,UpdatedAt = u.UpdatedAt,
            Answer = u.Answer,
            DeadLine = u.DeadLine,
            IdProduct = u.IdProduct,
            Answers = u.AnswersUsers.Count,
        };
        public static Quiz ToEntity(QuizDto u) => new()
        {
            Id = u.Id,
            Name = u.Name,
            Description = u.Description,
            CreatedAt = u.CreatedAt,
            UpdatedBy = u.UpdatedBy,
            CreatedBy = u.CreatedBy,UpdatedAt = u.UpdatedAt,
            Answer = u.Answer,
            DeadLine = u.DeadLine,
            IdProduct = u.IdProduct,
        };
    }
}