namespace Application.DTOs.Product;

public class ProductRequestDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Pricing { get; set; } = 0;
    public bool Availability { get; set; } = true;
    public int CategoryId { get; set; } = 0;
}