using Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Category
{
    public interface ICategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<GetProductDto> Products { get; set; }
    }
}
