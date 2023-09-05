using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetProducts;

public class GetProductListQuery : IRequest<List<ProductDetailsDto>>
{
}
