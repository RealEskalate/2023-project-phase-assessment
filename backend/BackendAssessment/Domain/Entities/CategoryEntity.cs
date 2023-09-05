using Domain.Common;

namespace Domain.Entities;

public class CategoryEntity : BaseDomainEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}