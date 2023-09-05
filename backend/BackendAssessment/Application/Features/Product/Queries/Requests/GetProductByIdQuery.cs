using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos;

namespace ProductHub.Application.Features.Products.Queries.Requests;
public class GetProductByIdQuery : IRequest<CommonResponse<ProductDto>>
{
    public int Id { get; set; }
}