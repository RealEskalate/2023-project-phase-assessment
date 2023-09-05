using Application.Dto.Product;
using MediatR;

namespace Application.Features.Product.Requests.Queries;

public record GetProductsRequest() : IRequest<IReadOnlyList<ProductDto>>;