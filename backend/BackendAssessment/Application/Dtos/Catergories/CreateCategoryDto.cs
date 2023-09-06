using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Common;

namespace Application.DTOs.Catergories
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}