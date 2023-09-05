namespace Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual Category Category { get; set; } = null!;
}