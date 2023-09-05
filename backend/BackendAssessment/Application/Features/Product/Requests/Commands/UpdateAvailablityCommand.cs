using Application.DTO;
using Application.Responses;
using MediatR;

namespace Application.Features.Product.Requests.Commands;

public class UpdateAvailablityCommand : IRequest<BaseCommandResponse<Unit>>
{
    public required ProductDTO productDTO { get; set; }
}