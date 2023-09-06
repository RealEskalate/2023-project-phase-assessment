using Domain.Common;

namespace Domain.Entites
{
    public class Booking : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public virtual User User { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        
    }
}