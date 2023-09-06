using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Products;
using ErrorOr;
using MediatR;

namespace Application.Features.Products.Request.Command
{
    public class DeleteProductRequest : IRequest<ErrorOr<ProductResponseDto>>
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        
    }
}