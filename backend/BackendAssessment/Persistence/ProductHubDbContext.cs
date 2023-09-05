using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;


public class ProductHubDbContext : DbContext {
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }


    public ProductHubDbContext(DbContextOptions<ProductHubDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductHubDbContext).Assembly);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(
            entity => {
                entity.HasIndex(u => u.Email).IsUnique();
                entity.HasIndex(u => u.Username).IsUnique();
                entity.Property(u => u.Email).HasMaxLength(50).IsRequired();
                entity.Property(u => u.Username).HasMaxLength(50).IsRequired();
                entity.Property(u => u.PasswordHash).HasMaxLength(50).IsRequired();
                entity.HasMany(u => u.Products).WithOne(p => p.User).HasForeignKey(p => p.UserId);

            }
        );

        modelBuilder.Entity<Category>(
            entity => {
                entity.HasIndex(c => c.Name).IsUnique();
                entity.Property(c => c.Name).HasMaxLength(50).IsRequired();
                entity.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);
            }
        );

        modelBuilder.Entity<Product>(
            entity => {
                entity.Property(p => p.Name).HasMaxLength(50).IsRequired();
                entity.Property(p => p.Description).HasMaxLength(200).IsRequired();
                entity.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
                entity.HasOne(p => p.User).WithMany(u => u.Products).HasForeignKey(p => p.UserId);
            }
        );
    }



}