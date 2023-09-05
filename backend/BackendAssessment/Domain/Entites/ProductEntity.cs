using Domain.Common;

namespace Domain.Entites;

public class ProductEntity : BaseDomainEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Pricing { get; set; }
    public bool Availability { get; set; } = true;
    public UserEntity ProductOwner { get; set; } = null!;
    public CategoryEntity Category { get; set; } = null!;
}