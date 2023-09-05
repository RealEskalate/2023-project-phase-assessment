using Assessment.Domain.Common;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations;

public class AssessmentDbContext : DbContext
{
    public AssessmentDbContext(DbContextOptions<AssessmentDbContext> options) : base(options){}

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    
    public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
    {
        foreach (var entry in base.ChangeTracker.Entries<EntityBase>()
                     .Where(q => q.State is EntityState.Added or EntityState.Modified))
        {
            entry.Entity.UpdatedAt= DateTime.UtcNow;

            if (entry.State != EntityState.Added) continue;

            entry.Entity.CreatedAt = DateTime.UtcNow;
        }

        var result = await base.SaveChangesAsync();

        return result;
    }
    
}