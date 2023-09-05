using ProductHub.Domain.Common;

namespace ProductHub.Domain.Entites;

public class Category : BaseEntity
{
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
    public virtual ICollection<Product> Products {get; set;} = null!;
}
