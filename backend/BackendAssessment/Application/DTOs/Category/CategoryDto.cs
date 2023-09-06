using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Category
{
    public class CategoryDto: ICategoryDto
    {
    
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}