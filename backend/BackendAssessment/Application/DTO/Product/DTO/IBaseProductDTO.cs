﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Product.DTO
{
    public interface IBaseProductDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

    }
}
