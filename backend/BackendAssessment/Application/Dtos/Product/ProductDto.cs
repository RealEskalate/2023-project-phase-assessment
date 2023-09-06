using Application.Common;
using Application.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product
{
    public class ProductDto : BaseDtoEntity, IProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CategoryDto Category { get; set; } = new CategoryDto();
        public int Pricing { get; set; }
        public bool Availablility { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
