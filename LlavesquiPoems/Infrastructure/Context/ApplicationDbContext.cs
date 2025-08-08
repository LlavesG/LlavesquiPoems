using LlavesquiPoems.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LlavesquiPoems.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Recital> Recitals { get; set; }
    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RecitalProduct>()
            .HasKey(rp => new { rp.IdProduct, rp.IdRecital });
    }
    
}