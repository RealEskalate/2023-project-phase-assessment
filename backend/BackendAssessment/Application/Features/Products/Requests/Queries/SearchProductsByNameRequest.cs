using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Products.Requests.Queries
{
    public class SearchProductsByNameRequest : IRequest<List<ProductListDto>>
    {
        public required string Name { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set;} = 10;
    }
}