using Domain.Common;

namespace Domain.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CatergoryId { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public virtual Category Category { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        
    }
}