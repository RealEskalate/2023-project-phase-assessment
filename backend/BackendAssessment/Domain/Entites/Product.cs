using ProductHub.Domain.Common;

namespace ProductHub.Domain.Entities;

public class Product: BaseEntity{
    public string Name{get; set;} =  null!;
    public double Pricing {get; set;} = 0;
    public Availability Availability{get; set;} = Availability.None;
    public virtual User User{get; set;} = null!;
    public virtual Category Category{get; set;} = null!;
}
public enum Availability
{
    IsAvailable,
    None,
    CommingSoon
}
