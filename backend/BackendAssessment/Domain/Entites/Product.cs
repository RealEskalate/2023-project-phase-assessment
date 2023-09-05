using Domain.Common;
using EmptyFiles;

namespace Domain.Entites;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Pricing { get; set; }
    public bool Availability { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
}