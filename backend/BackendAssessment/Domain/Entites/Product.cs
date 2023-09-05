using Domain.Common;

namespace Domain.Entites;

public class Product : BaseCommonEntity
{
    public int ProductId { get; set; }
    public Category? Category { get; set; }
    public int Pricing { get; set; }
    public bool Availablity { get; set; }
    public required User User { get; set; }
    public int UserId { get; set; }
}
