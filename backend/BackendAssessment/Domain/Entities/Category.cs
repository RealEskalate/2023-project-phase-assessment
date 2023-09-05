namespace Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
    
    public virtual User User { get; set; } = null!;
    public virtual ICollection<Product> Products { get; set; } = null!;
}