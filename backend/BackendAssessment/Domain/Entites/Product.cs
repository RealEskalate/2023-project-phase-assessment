
using ProductHub.Domain.Common;

namespace ProductHub.Domain.Entities;

public class Product: BaseEntity{
    public string Name{get; set;} =  null!;
    public double Pricing {get; set;} = 0;
    public Availability Availability{get; set;} = Availability.None;


}
public enum Availability
{
    IsAvailable,
    None 
}
