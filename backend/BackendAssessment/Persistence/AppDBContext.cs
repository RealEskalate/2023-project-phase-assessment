using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDBContext : DbContext
{
    public DbSet<ProductEntity> Product { get; set; }
    public DbSet<CategoryEntity> Category { get; set; }
    public DbSet<UserEntity> User { get; set; }

    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
        
    }
}