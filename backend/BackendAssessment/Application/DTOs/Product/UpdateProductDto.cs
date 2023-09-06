using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class UpdateProductDto : IProductDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public Guid CatagoryId { get; set; }
        public double Pricing { get; set; }
        public int Quantity { get; set; }
    }
}