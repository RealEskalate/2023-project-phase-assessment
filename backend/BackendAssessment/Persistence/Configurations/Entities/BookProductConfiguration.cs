using Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations.Entities
{
    public class BookProductConfiguration : IEntityTypeConfiguration<BookProduct>
    {
        public void Configure(EntityTypeBuilder<BookProduct> builder)
        {
        }
    }
}
