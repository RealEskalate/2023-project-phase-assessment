using Domain.Entites.Common;

namespace Domain.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public double Pricing { get; set; }
        public bool Availability { get; set; }

        public Guid UserId { get; set; }
        public virtual User? User { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}