using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ProductResponseDto>
{
    public int CategoryId { get; set; }
    public int ProductOwnerId { get; set; }
    public ProductRequestDto ProductDto { get; set; } = null!;
}