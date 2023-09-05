using Application.Dto.Product;
using MediatR;

namespace Application.Features.Product.Requests.Command;

public record CreateProductRequest(ProductCreationDto ProductCreationDto) : IRequest<ProductDto>;