using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Unit>
{
    public CreateProductDto Product { get; set; }
}
