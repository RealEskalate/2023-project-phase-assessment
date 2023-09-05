using Backend.Domain.Entities.Common;

namespace Backend.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { set; get; } = null!;
        public string Description { set; get; } = null!;
        public string Image { set; get; } = null!;
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public string Brand { set; get; } = null!;
        public ICollection<Category>? Categories { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        public User? User { get; set; }
        public Guid UserId { get; set; }
    }
}