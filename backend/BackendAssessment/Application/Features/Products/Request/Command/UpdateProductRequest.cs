using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Products;
using ErrorOr;
using MediatR;

namespace Application.Features.Products.Request.Command
{
    public class UpdateProductRequest : IRequest<ErrorOr<ProductResponseDto>>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public ProductDetailDto ProductDetailDto { get; set; } = null!;
        
    }
}