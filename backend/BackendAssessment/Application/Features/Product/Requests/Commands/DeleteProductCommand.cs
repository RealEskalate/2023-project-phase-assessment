using Application.Response;
using MediatR;

namespace Application.Features.Product.Requests.Commands;

public class DeleteProductCommand  : IRequest<BaseCommandResponse<Unit>>
{
    public required int Id{ get; set; }
    public required int UserId{ get; set; }
    
}
