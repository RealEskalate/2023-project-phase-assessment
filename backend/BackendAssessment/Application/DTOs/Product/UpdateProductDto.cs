using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class UpdateProductDto : BaseEntityDto
    {
        public bool isAvailable { get; set; }
        public double pricing { get; set; }
    }
}
