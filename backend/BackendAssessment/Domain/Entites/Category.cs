using Assessment.Domain.Common;

namespace Assessment.Domain.Entities;

public class Category : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
