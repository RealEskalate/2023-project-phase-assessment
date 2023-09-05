using Domain.Common;

namespace Domain.Entities;

public class Booking : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}
