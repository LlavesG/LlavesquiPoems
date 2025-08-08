namespace LlavesquiPoems.Domain.Entities;

public class RecitalProduct
{
    public int IdProduct { get; set; }
    public int IdRecital { get; set; } 
    public Recital Recital { get; set; }
    public Product Product { get; set; } 
}