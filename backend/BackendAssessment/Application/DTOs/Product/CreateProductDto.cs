using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class CreateProductDto: IProductDto
    {
        public Guid CategoryId { get; set; }
        
    }
}