using Microsoft.EntityFrameworkCore;
using ProductHub.Domain.Entites;

namespace ProductHub.Persistence;

public class ProductHubDbContext : DbContext
{
    public ProductHubDbContext(DbContextOptions<ProductHubDbContext> options) : 
        base(options) { }

    // Define DbSet properties for your entities
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Define entity configurations and relationships here

        // User entity
        modelBuilder.Entity<User>()
            .HasMany(user => user.Products)
            .WithOne(product => product.User)
            .HasForeignKey(product => product.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Product entity
        modelBuilder.Entity<Product>()
            .HasOne(product => product.Category)
            .WithMany(category => category.Products)
            .HasForeignKey(product => product.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>()
            .HasKey(category => category.Id);
        
        modelBuilder.Entity<Product>()
            .HasKey(product => product.Id);
        
        modelBuilder.Entity<User>()
            .HasKey(user => user.Id);

        // Category entity
        modelBuilder.Entity<Category>()
            .HasMany(category => category.Products)
            .WithOne(product => product.Category)
            .HasForeignKey(product => product.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
