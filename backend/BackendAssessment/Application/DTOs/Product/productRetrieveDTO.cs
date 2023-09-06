using Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class productRetrieveDTO
    {
        public string name { get; set; }
        public string description { get; set; }
        public string availability { get; set; }
        public string pricing { get; set; }
        public CategoryRetriveDto category { get; set; }

    }
}
