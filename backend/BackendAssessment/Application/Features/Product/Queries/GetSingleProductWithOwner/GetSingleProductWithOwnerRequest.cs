using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetSingleProductWithOwner;

public class GetSingleProductWithOwnerRequest : IRequest<ProductResponseDto>
{
    public int ProductId { get; set; }
}