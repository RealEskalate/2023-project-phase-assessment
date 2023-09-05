using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<Unit>
{
    public ProductDetailsDto Product { get; set;}
}
