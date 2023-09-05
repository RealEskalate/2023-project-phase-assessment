using BackendAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class AssessmentDbContext : DbContext
    {
        public AssessmentDbContext(DbContextOptions<AssessmentDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssessmentDbContext).Assembly);
            
            modelBuilder.Entity<Product>()
                .HasKey(e => new { e.Id });
            modelBuilder.Entity<Category>()
                .HasKey(e => new { e.Id });
            modelBuilder.Entity<Booking>()
                .HasKey(e => new { e.Id });
            modelBuilder.Entity<User>()
                .HasKey(e => new { e.Id });
         
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
