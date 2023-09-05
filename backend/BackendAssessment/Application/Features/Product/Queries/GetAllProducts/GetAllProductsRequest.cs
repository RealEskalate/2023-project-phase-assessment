using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsRequest : IRequest<List<ProductResponseDto>>
{
    
}