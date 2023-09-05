using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<ProductDto>
{
    public Guid ProductId { get; set; }
    public ProductReqResDto ProductReqResDto { get; set; } = null!;
}