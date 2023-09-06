using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Products;
using ErrorOr;
using MediatR;

namespace Application.Features.Products.Request.Queries
{
    public class GetAllProductRequest : IRequest<ErrorOr<List<ProductResponseDto>>>
    {
        public int UserId { get; set; }   
    }
}