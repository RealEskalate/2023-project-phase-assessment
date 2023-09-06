using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class UpdateProductDto: IProductDto
    {
        public Guid Id { get; set; }
        
    }
}