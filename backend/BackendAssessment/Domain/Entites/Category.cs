using Domain.Entites.Common;

namespace Domain.Entites
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public virtual ICollection<Product> Products { get; set; }
    }
}