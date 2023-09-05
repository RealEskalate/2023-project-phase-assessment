namespace Application.Dto.Product;

public record ProductDto(int Id, string Name, string Description, decimal Price, int CategoryId, int Stock);