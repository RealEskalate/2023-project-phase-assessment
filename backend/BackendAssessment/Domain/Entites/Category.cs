
using ProductHub.Domain.Common;

namespace ProductHub.Domain.Entities;

public class Category: BaseEntity{
    public string Name{get; set;} =  null!;
    public string Description{get;} = null!;
    public ICollection<Product> Categories{get; set;} = new List<Product>();
    
}
