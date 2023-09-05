using Application.Common.Responses;
using Application.Features.Products.Dtos;
using MediatR;

namespace Application.Features.Products.Queries.Requests;

public class GetProductRequest : IRequest<CommonResponse<ProductDto>>
{
    public int ProductId { get; set; }
}
