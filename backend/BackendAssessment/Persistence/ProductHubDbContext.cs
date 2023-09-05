using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ProductHubDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;

    public ProductHubDbContext(DbContextOptions<ProductHubDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Product>()
            .HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Product_User");

        modelBuilder
            .Entity<Product>()
            .HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity(j => j.ToTable("ProductCategories"));

        modelBuilder
            .Entity<Booking>()
            .HasOne(b => b.Product)
            .WithMany(p => p.Bookings)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Booking_Product");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder) { }
}
