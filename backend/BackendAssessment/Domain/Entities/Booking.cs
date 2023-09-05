namespace Domain.Entities;

public class Booking : BaseEntity
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; } = string.Empty;

    public virtual User User { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}