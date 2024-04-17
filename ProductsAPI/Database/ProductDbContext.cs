using Microsoft.EntityFrameworkCore;
using ProductsAPI.Database.Data;

namespace ProductsAPI.Database;

public class ProductDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var productBuilder = modelBuilder.Entity<Product>();
        productBuilder.HasKey(x => x.Id);
        productBuilder.HasIndex(x => x.Id).IsUnique();
        productBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        productBuilder.Property(x => x.Description).IsRequired().HasMaxLength(250);
        productBuilder.Property(x => x.Price).IsRequired();
        productBuilder.Property(x => x.Currency).IsRequired();
    }
}