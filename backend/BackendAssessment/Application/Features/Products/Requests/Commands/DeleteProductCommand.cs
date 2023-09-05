using MediatR;
using ProductHub.Application.Common.Responses;

namespace ProductHub.Application.Features.Products.Requests.Commands;

public class DeleteProductCommand : IRequest<CommonResponse<Unit>>
{
    public int ProductId {get; set;}
}
