using Microsoft.EntityFrameworkCore;

namespace LlavesquiPoems.Domain.Entities;

public class RecitalProduct
{
    public int IdProduct { get; set; }
    public int IdRecital { get; set; } 
    public virtual Recital Recital { get; set; }
    public virtual Product Product { get; set; } 
}