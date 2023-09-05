using Domain.Entites;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(p => p.products)
                .WithOne(u => u.user)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany(p => p.products)
                    .WithOne(c => c.category)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(p => p.user)
                .WithMany(c => c.products);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(c => c.category)
                    .WithMany(p => p.products)
                    .OnDelete(DeleteBehavior.Cascade);
            });


        }

    }
}
