using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetSingleProduct;

public class GetSingleProductCommand : IRequest<ProductDto>
{
    public Guid ProductId { get; set; }
}