using BackendAssessment.Domain.Common;

namespace BackendAssessment.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Availability { get; set; }
    public int Pricing { get; set; }
    public int UserId { get; set; }
    
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}