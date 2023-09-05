using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Pricing { get; set; }
        public int Availability { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }

}