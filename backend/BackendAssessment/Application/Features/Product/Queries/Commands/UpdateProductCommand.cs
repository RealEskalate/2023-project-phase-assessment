using Application.Common.Responses;
using Application.Features.Product.Dtos;
using MediatR;

namespace Application.Features.Product.Queries.Commands;

public class UpdateProductCommand : IRequest<CommonResponse<Unit>>
{
    public UpdateProductDto UpdateProductDto { get; set; } = null!;
}
