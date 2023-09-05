using Application.Dto.Product;
using MediatR;

namespace Application.Features.Product.Requests.Queries;

public record GetProductByIdRequest(int ProductId) : IRequest<ProductDto?>;