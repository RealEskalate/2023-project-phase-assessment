using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations.Entities
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Booking> builder)
        {
            
            builder                                        
                .HasOne(u => u.Product)
                .WithMany( u => u.Bookings)
                .HasForeignKey(u => u.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder                                        
                .HasOne(u => u.User)
                .WithMany( u => u.Bookings)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}