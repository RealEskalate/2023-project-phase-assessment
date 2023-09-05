using MediatR;

namespace Application.Features.Product.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest<Unit>
{
    public int ProductId { get; set; }
}