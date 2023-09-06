using Application.Dtos.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Request.Queries
{
    public class GetAllProductsRequest : IRequest<List<ProductDto>>
    {
        public Guid UserId { get; set; }
    }
}
