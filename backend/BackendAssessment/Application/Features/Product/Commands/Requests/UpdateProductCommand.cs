using MediatR;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Common.Responses;

namespace ProductHub.Application.Features.Products.Commands.Requests;

public class UpdateProductCommand : IRequest<CommonResponse<int>>
{
    public UpdateProductDto UpdateProductDto { get; set; } = null!;

}
