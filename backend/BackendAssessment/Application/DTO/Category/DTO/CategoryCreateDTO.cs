﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Category.DTO
{
    public class CategoryCreateDTO : ICategoryDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
