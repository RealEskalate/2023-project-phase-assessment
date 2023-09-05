namespace Application.DTOs.Product;

public class UpdateProductDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Pricing { get; set; }
    public bool? Availability { get; set; }
}