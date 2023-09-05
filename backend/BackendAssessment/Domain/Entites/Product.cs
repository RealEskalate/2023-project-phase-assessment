



namespace Domain.Entites
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Pricing { get; set; }
        public int Availability { get; set; }

        // Foreign key for user who owns this product
        public int UserId { get; set; }
        public User User { get; set; }

        // Foreign key for category of this product
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
