using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsCommand : IRequest<List<ProductDto>>
{
    public Guid ProductId { get; set; }
}