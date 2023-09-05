using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Pricing { get; set; }
        public int Availability { get; set; }

        // Relationships
        public int UserId { get; set; } // Foreign key for product owner
        public User User { get; set; } // Navigation property for product owner

        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
