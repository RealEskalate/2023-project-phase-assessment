using Application.Common.Responses;
using MediatR;

namespace Application.Features.Product.Queries.Commands;

public class DeleteProductCommand : IRequest<CommonResponse<Unit>>
{
    public int ProductId { get; set; }
}
