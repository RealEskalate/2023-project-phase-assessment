using ProductHub.Domain.Entities;

namespace ProductHub.Application.DTOs.ProductDtos;
public class ProductDto
{
    public int Id { get; set; }
    public int CreatorId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; }
    public double Pricing { get; set; }
    public Availability Availability { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
