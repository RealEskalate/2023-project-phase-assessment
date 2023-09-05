using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos;

namespace ProductHub.Application.Features.Products.Requests.Queries;

public class GetProductListRequest : IRequest<CommonResponse<List<ProductDto>>>
{
    public int UserId {get; set;}
}
