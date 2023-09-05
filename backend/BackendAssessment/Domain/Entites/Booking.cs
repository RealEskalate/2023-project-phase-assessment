using Domain.Common;

namespace Domain.Entities;

public class Booking: BaseEntity{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual Product Product { get; set; } = null!;
}