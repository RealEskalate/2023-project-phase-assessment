using Domain.Entites;
using Domain.Entites.Categories;
using Domain.Entites.Products;


namespace Persistence;


using Microsoft.EntityFrameworkCore;


public class ProductHubDbContext : AuditableDbContext
{
    public ProductHubDbContext(DbContextOptions<ProductHubDbContext> option) : base(option){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductHubDbContext).Assembly);
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    

}