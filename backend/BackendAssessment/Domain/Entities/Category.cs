using Backend.Domain.Entities.Common;

namespace Backend.Domain.Entities
{
    public class Category: BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Name { set; get; } = null!;
        public string? Description { get; set; }
        public Product? Product { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}