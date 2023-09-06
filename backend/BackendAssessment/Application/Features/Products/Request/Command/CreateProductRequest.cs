using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Products;
using ErrorOr;
using MediatR;

namespace Application.Features.Products.Request.Command
{
    public class CreateProductRequest : IRequest<ErrorOr<ProductResponseDto>>
    {
        public ProductDetailDto ProductDetailDto { get; set; } = null!;
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}