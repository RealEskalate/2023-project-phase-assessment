using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos;

namespace ProductHub.Application.Features.Products.Requests.Commands;

public class UpdateProductCommand : IRequest<CommonResponse<int>>
{
    public required ProductUpdateDto ProductUpdateDto {get; set;}
}
