using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;

namespace Application.DTO.ProductDTO.DTO
{
    public class ProductCreateDTO : IBaseProductDTO
    {
        public string? Name {get; set;}
        public string? Description {get; set;}
        public decimal Price {get; set;}
        public bool IsInStock {get; set;}
        
    }
}
