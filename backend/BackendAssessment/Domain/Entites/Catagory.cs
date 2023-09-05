using Domain.Common;

namespace Domain.Entites;

public class Catagory : BaseEntity
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public ICollection<Product> Products { get; set; }
}