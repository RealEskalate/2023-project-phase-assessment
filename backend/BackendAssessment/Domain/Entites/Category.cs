using Domain.Common;

namespace Domain.Entities;
public class Category : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

}