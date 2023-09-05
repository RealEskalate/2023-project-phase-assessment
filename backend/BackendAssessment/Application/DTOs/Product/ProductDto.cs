namespace Backend.Application.DTOs.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; } = null!;
    public string Brand { get; set; } = null!;
}