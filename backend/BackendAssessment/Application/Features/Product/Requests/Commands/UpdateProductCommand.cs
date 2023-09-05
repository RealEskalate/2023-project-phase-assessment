using Application.DTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Product.Requests.Commands;

public class UpdateProductCommand : IRequest<BaseCommandResponse<Unit>>
{
    public required ProductDTO productDTO { get; set; }
}