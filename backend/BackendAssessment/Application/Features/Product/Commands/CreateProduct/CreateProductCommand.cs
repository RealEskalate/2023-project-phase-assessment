using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<ProductDto>
{
    public CreateProductDto CreateProductDto { get; set; } = null!;
}