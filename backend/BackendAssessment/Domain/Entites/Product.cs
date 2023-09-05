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
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; } = new Category();
        public int Pricing { get; set; }
        public bool Availablility { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
