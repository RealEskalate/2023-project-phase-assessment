using Application.Common.Responses;
using MediatR;

namespace Application.Features.Products.Queries.Commands;

public class DeleteProductCommand : IRequest<CommonResponse<Unit>>
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
