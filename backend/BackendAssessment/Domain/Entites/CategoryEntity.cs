using Domain.Common;

namespace Domain.Entites;

public class CategoryEntity : BaseDomainEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<ProductEntity> Products { get; set; } = null!;
}