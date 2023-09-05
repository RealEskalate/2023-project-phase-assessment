
using Application.Dtos.Product;
using MediatR;

namespace Application.Features.Product.Commands.Create;

public class CreateProductCommand : IRequest<ProductResponseDto>
{
    public ProductRequestDto NewProduct { get; set; } = null!;
}