using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<ProductResponseDto>
{
    public int ProductId { get; set; }
    public UpdateProductDto ProductDto { get; set; } = null!;
}