using Application.Dtos.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetSingle;

public class GetSingleProductRequest : IRequest<ProductResponseDto>
{
    public Guid ProductId { get; set; }
}