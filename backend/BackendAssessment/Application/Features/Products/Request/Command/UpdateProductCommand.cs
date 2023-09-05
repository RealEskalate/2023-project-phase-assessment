using Application.DTO.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Request.Command
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public ProductDto product { set; get; } 
    }
}
