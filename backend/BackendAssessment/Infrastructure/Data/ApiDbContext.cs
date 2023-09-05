using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;

namespace Backend.Infrastructure.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
            .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p!.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c!.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<User>()
                .HasMany(u => u!.Products)
                .WithOne(p => p!.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p!.Categories)
                .WithOne(c => c!.Product)
                .HasForeignKey(c => c.ProductId);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<Category> Categories { get; set; }
    
    }
}