using Application.Dtos.Product;
using MediatR;

namespace Application.Features.Product.Queries.GetAll;

public class GetAllProductRequest : IRequest<IReadOnlyList<ProductResponseDto>>
{

}