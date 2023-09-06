﻿using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product
{
    public class UpdateProductDto :BaseDtoEntity, IProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Pricing { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
