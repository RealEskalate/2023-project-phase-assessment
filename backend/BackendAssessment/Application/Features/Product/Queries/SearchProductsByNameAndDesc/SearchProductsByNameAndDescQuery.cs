using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Queries.SearchProductsByNameAndDesc;

public class SearchProductsByNameAndDescQuery : IRequest<List<ProductResponseDto>>
{
    public string Name { get; set; } = null!;
}