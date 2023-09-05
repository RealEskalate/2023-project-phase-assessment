using Application.Dto.Product;
using MediatR;

namespace Application.Features.Product.Requests.Command;

public record UpdateProductRequest(ProductDto ProductCreationDto) : IRequest<Unit>;