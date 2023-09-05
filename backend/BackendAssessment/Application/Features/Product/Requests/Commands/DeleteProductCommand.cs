using Application.Responses;
using MediatR;

namespace Application.Features.Product.Requests.Commands;

public class DeleteProductCommand : IRequest<BaseCommandResponse<Unit>>
{
    public int ProductId { get; set; }
    public int UserId{ get; set; }
}