using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetProductDetail;

public class GetProductDetailQuery : IRequest<ProductDetailsDto>
{
    public Guid Id { get; set; }
}
