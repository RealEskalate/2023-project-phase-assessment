using Application.DTOs.Common.Models;

namespace Application.DTOs.Product;

public class ProductDetailsDto : EntityBaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid CategoryId { get; set; }
    public Domain.Entites.Categories.Category Category { get; set; }
}