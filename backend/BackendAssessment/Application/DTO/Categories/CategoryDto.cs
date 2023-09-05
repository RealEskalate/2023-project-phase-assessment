using Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Categories
{
    public class CategoryDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
