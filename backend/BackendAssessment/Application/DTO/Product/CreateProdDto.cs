namespace Application.DTO.Product;

public class CreateProdDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int AvailableQuantity { get; set; }
}