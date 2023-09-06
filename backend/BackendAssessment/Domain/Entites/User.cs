using Domain.Entites.Common;

namespace Domain.Entites
{
    public class User : BaseEntity
    {
        public User()
        {
            Products = new HashSet<Product>();
        }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}