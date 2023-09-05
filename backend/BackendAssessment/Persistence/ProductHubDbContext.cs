using Microsoft.EntityFrameworkCore;
using ProductHub.Domain.Common;
using ProductHub.Domain.Entities;

namespace ProductHub.Persistence;
public class ProductHubDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    public ProductHubDbContext(DbContextOptions<ProductHubDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.CreatedAt).IsRequired();
            entity.Property(u => u.ModfiedAt).IsRequired();

        });

        modelBuilder.Entity<Product>(entity =>
        {

            entity.HasKey(e => e.Id);
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.ModfiedAt).IsRequired();

            entity
                .HasOne(e => e.User)
                .WithMany(u => u.Products)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.CreatedAt);
            entity.Property(i => i.ModfiedAt);
        });



    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            entry.Entity.ModfiedAt = DateTime.Now.ToUniversalTime();
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now.ToUniversalTime();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}