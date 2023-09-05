using Application.DTOs.Common;
using Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Categorys
{
    public class CategoryDetailsDto : BaseDto
    {
        public string Name { get; set; }    
        
        public string Description { get; set; }

        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
