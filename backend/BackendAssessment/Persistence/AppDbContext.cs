using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext
        (DbContextOptions<AppDbContext
        > options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext
            ).Assembly);
        }
    }
}
