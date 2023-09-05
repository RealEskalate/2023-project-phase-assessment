using Domain.Common;

namespace Domain.Entities;

public class ProductEntity : BaseDomainEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public float Pricing { get; set; }
    public bool Availability { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
    // add list of categories as relationship, a product can have many categories
    // public CategoryEntity Category { get; set; } = null!;
}