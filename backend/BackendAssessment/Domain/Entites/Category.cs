using Domain.Common;

namespace Domain.Entites;

public class Category : BaseCommonEntity
{
    public int CategoryId { get; set; }
    public List<Product> Products { get; set; }
}
