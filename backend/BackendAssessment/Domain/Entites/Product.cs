using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entites
{
    public class Product : EntityBase
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public Guid CatagoryId { get; set; }
        public double Pricing { get; set; }
        public int Quantity { get; set; }
        public required Catagory Catagory { get; set; }
    }
}