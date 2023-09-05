using ProductHub.Domain.Entities;

namespace ProductHub.Application.DTOs.ProductDtos;
public class UpdateProductDto
{
    public int Id{get; set;}   
    public int ActorId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Pricing { get; set; }
    public int CategoryId { get; set; }
    public Availability Availability { get; set; }
}