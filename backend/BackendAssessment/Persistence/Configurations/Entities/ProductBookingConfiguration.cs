using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Entities
{
    public class ProductBookingConfiguration : IEntityTypeConfiguration<ProductBooking>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductBooking> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.UserId });
            builder.HasOne(x => x.Product).WithMany(x => x.Bookings).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.User).WithMany(x => x.Bookings).HasForeignKey(x => x.UserId);
        }   

    }
}
