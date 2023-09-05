using Application.Common.Responses;
using Application.Features.Product.Dtos;
using MediatR;

namespace Application.Features.Product.Queries.Commands;

public class CreateProductCommand : IRequest<CommonResponse<int>>
{
    public CreateProductDto CreateProductDto { get; set; } = null!;
}
