using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetSingleProduct;

public class GetSingleProductRequest : IRequest<ProductResponseDto>
{
    public int Id { get; set; }
}