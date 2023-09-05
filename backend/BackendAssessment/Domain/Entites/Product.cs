using ProductHub.Domain.Common;

namespace ProductHub.Domain.Entites;

public class Product : BaseEntity
{
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
    public int Price {get; set;}
    public int UserId {get; set;}
    public int CategoryId {get; set;}
    public bool Availability {get; set;}

    public virtual User User {get; set;} = null!;
    public virtual Category Category {get; set;} = null!;
}
