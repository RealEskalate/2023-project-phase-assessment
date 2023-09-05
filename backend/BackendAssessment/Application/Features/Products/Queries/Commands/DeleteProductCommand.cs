using Application.Common.Responses;
using MediatR;

namespace Application.Features.Products.Queries.Commands;

public class DeleteProductCommand : IRequest<CommonResponse<Unit>>
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}
