using MediatR;

namespace Application.Features.Product.Commands.Delete;

public class DeleteProductCommand : IRequest<Unit>
{
    public Guid ProductId { get; set; }
}