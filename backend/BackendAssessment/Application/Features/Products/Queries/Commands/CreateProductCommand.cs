using Application.Common.Responses;
using Application.Features.Products.Dtos;
using MediatR;

namespace Application.Features.Products.Queries.Commands;

public class CreateProductCommand : IRequest<CommonResponse<int>>
{
    public int UserId { get; set; }
    public ProductDto CreateProductDto { get; set; } = null!;
}
