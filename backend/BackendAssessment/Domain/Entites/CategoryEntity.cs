
namespace Domain.Entities;

public class CategoryEntity : BaseEntity
{
    public string Name { get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<ProductEntity>? Products { get; set; }
}
