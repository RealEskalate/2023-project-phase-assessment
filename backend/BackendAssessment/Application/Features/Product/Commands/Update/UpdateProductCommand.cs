
using Application.Dtos.Product;
using MediatR;

namespace Application.Features.Product.Commands.Update;

public class UpdateProductCommand : IRequest<ProductResponseDto>
{
    public Guid ProductId { get; set; }
    public ProductRequestDto UpdateProduct { get; set; } = null!;
}