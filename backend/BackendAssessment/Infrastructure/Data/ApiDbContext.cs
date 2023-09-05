using Microsoft.EntityFrameworkCore;
using Domain.Entites;

namespace Infrastructure.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
        }

        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}