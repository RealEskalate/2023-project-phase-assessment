using Application.Common.Responses;
using Application.Features.Products.Dtos;
using MediatR;

namespace Application.Features.Products.Queries.Commands;

public class UpdateProductCommand : IRequest<CommonResponse<Unit>>
{
    public int UserId { get; set; }
    public ProductDto UpdateProductDto { get; set; } = null!;
}
