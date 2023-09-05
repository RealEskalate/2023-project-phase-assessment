using Microsoft.EntityFrameworkCore;
using BackendAssessment.Domain.Common;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Persistence;

public class BackendAssessmentDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;


    public BackendAssessmentDbContext(DbContextOptions<BackendAssessmentDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasMany(u => u.Products);
            entity.Property(u => u.CreatedAt).IsRequired();
            entity.Property(u => u.LastModified).IsRequired();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).IsRequired();

            entity.Property(e => e.UserId).IsRequired();

            entity.Property(e => e.CreatedAt).IsRequired();

            entity.Property(e => e.LastModified).IsRequired();

            entity
                .HasOne(e => e.User)
                .WithMany(u => u.Products)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(e => e.Category)
                .WithMany(u => u.Products)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(i => i.Id);
            entity.Property(i => i.CreatedAt);
            entity.Property(i => i.LastModified);
            entity.Property(i => i.Name).IsRequired();
            entity.Property((i => i.Description)).IsRequired();
            entity.Property(i => i.ProductId).IsRequired();
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            entry.Entity.LastModified = DateTime.Now.ToUniversalTime();
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now.ToUniversalTime();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}