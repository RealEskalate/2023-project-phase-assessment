using Domain.Common;

namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public int Price { get; set; }
    public int Stock { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = null!;
}
