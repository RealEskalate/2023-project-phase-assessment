using Application.DTOs.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Requests.Command
{
    public class CreateProductRequest : IRequest<ProductDto>
    {
        public CreateProductDto CreateProductDto { get; set; }
    }
}
