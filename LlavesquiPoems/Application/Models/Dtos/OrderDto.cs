namespace LlavesquiPoems.Application.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public int IdProduct { get; set; }
    public int State { get; set; } 
    public string ProductName { get; set; } 
    public int?  IdRecital { get; set; }
    public double Price { get; set; }
    public string RecitalName { get; set; }
    public DateTime? RecitalDate { get; set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime UpdatedAt { get;  set; }
}