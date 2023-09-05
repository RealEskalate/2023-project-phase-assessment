using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

    }

     public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var entities = ChangeTracker.Entries()
            .Where(entry => entry.State == EntityState.Modified)
            .Select(entry => entry.Entity);

        foreach (var entity in entities)
        {
            var updatedAtProperty = entity.GetType().GetProperty("ModifiedAt");
            if (updatedAtProperty != null && updatedAtProperty.PropertyType == typeof(DateTime))
            {
                updatedAtProperty.SetValue(entity, DateTime.UtcNow);
            }
        }
    }
}