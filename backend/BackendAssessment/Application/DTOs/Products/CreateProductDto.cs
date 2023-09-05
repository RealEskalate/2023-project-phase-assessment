using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Products
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set;}

        public int UserId { get; set; } 
        public int Availability { get; set; }

        public double Price { get; set; }

    }
}
