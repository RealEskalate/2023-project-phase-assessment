using MediatR;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Common.Responses;

namespace ProductHub.Application.Features.Products.Commands.Requests;

public class DeleteProductCommand : IRequest<CommonResponse<int>>
{
    public DeleteProductDto DeleteProductDto { get; set; } = null!;

}
