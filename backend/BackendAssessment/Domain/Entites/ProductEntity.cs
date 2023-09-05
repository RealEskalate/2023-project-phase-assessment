
namespace Domain.Entities;

public class ProductEntity : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Pricing { get; set; } = 0.0;
    public bool Availability { get; set; } = false;
    public CategoryEntity? Category { get; set; }
}
