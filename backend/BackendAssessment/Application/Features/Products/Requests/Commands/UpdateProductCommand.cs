using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Products.Requests.Commands
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public required UpdateProductDto UpdateProductDto { get; set; }
        public Guid RequestingUserId { get; set; }
    }
}