using Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Products
{
    public class ProductDto: BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
