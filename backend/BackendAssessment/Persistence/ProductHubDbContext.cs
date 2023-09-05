using Microsoft.EntityFrameworkCore;
using Domain.Entites;

namespace Persistence
{
    public class ProductHubDbContext : DbContext
    {
        public ProductHubDbContext(DbContextOptions<ProductHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
