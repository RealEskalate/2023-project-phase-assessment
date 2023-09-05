using Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Request.Queries
{
    public class GetProductRequest : IRequest<CreateProductDTO>
    {
        public Guid Id { get; set; }
    }
}
