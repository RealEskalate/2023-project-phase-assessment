using MediatR;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Common.Responses;

namespace ProductHub.Application.Features.Products.Commands.Requests;

public class CreateProductCommand : IRequest<CommonResponse<int>>
{
    public CreateProductDto CreateProductDto { get; set; } = null!;

}
