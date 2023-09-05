using Domain.Common;

namespace Domain.Entites;

public class Booking : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Quantity { get; set; }
}