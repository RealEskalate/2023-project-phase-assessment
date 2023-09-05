using Application.Dto.Product;
using MediatR;

namespace Application.Features.Product.Requests.Queries;

public record GetProductsByCategoryIdRequest(int CategoryId) : IRequest<IReadOnlyList<ProductDto>>;