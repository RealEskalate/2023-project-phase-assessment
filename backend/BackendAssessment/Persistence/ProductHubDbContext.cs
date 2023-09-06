using Domain.Entities.Product;
using Domain.Entities.Category;

namespace Persistence;
using Microsoft.EntityFrameworkCore;
public class ProductHubDbContext : AuditableDbContext
{
    public ProductHubDbContext(DbContextOptions<ProductHubDbContext> option) : base(option){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductHubDbContext).Assembly);
    }
    public DbSet<Product> Products { get; set; } = null!;

     public DbSet<Category> Categories { get; set; } = null!;
    

}