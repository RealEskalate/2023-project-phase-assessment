using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.ProductDtos;
namespace ProductHub.Application.Features.Products.Requests.Commands;

public class CreateProductCommand : IRequest<CommonResponse<int>>
{
    public required ProductCreateDto ProductCreateDto {get; set;}
}
