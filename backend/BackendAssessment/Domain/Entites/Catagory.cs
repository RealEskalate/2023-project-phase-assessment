using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entites
{
    public class Catagory : EntityBase
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}