using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Products.Requests.Queries
{
    public class GetProductDetailRequest : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}