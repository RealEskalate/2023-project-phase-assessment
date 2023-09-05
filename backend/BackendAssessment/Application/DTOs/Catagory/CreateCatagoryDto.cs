using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Catagory
{
    public class CreateCatagoryDto : ICatagoryDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}