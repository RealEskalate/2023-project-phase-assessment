using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ProductHubDbContext : AuditableDbContext
    {
        public ProductHubDbContext(DbContextOptions<ProductHubDbContext> option) : base(option){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductHubDbContext).Assembly);
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Catagory> Catagories { get; set; } = null!;
    }
}