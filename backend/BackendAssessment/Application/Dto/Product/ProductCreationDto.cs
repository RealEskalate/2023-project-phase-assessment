using MediatR;

namespace Application.Dto.Product;

public record ProductCreationDto(string Name, string Description, double Price, int Stock, int CategoryId) : IRequest<ProductDto>;