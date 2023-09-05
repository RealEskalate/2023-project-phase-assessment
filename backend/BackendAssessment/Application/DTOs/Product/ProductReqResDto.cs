namespace Application.DTOs.Product;

public class ProductReqResDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public float Pricing { get; set; }
    public bool Availability { get; set; }
    public Guid CategoryId { get; set; }
}