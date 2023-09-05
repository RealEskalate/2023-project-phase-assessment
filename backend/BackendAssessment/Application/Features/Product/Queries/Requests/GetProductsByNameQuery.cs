using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos;

namespace ProductHub.Application.Features.Products.Queries.Requests;
public class GetProductsByNameQuery : IRequest<CommonResponse<List<ProductDto>>>
{
    public string Name { get; set; } = null!;
}