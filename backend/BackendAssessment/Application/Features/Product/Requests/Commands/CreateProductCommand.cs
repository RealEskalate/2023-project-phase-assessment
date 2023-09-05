using Application.DTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Product.Requests.Commands;

public class CreateProductCommand : IRequest<BaseCommandResponse<int>>
{
    public required ProductDTO productDTO { get; set; }
}