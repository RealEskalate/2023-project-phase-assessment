using Domain.Common.Models;
using Domain.Entites.Categories;

namespace Domain.Entites.Products;

public class Product : EntityBase
{
    //Name, description, category, pricing, availability
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int AvailableQuantity { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public Guid UserId { get; set; }
    
}