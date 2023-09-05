using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence;

public class ProductHubDbContext : DbContext
{
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    // public virtual DbSet<ApplicaionUser> Users { get; set; }

    public ProductHubDbContext(DbContextOptions<ProductHubDbContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        // base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<ApplicaionUser>().ToTable("AspNetUsers");
        // modelBuilder.Entity<ApplicaionUser>(
        //     entity => {
        //         entity
        //             .HasMany(e => e.Products)
        //             .WithOne(e => e.User)
        //             .OnDelete(DeleteBehavior.Cascade)
        //             .HasConstraintName("FK_User_Product");
        //         
        //     }
        // );

        modelBuilder.Entity<Product>(
            entity => {
                entity
                    .Property(e => e.Id)
                    .UseIdentityColumn();
                // entity
                //     .HasOne(e => e.User)
                //     .WithMany(e => e.Products);
                entity
                    .HasOne(e => e.Category)
                    .WithMany(e => e.Products);
            }
        );
       
        modelBuilder.Entity<Category>(
            entity => {
                entity
                    .Property(e => e.Id)
                    .UseIdentityColumn();
                entity
                    .HasMany(e => e.Products)
                    .WithOne(e => e.Category)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Category_Product");
            }
        );
        

    }
    
}