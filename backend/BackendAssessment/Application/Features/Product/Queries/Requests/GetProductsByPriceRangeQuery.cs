
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos;

namespace ProductHub.Application.Features.Products.Queries.Requests;
public class GetProductsByPriceRangeQuery : IRequest<CommonResponse<List<ProductDto>>>
{
    public double startingPrice { get; set; }
    public double finalPrice { get; set; }
}