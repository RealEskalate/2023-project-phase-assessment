using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class ProductDto: IProductDto
    {
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
       
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}