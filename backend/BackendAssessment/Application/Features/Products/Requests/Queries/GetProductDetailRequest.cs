using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos;

namespace ProductHub.Application.Features.Products.Requests.Queries;

public class GetProductDetailRequest : IRequest<CommonResponse<ProductDto>>
{
    public int Id {get; set;}
}
