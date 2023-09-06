using Domain.Common;

namespace Domain.Entites
{
    public class User : BaseEntity
    {
        public User()
        {
            Products = new HashSet<Product>();
            Bookings = new HashSet<Booking>();
        }

        public string FirstName { set; get; } = null!;
        public string LastName { set; get; } = null!;
        public string UserName { set; get; } = null!;
        public string Email { set; get; } = null!;
        public string Password { set; get; } = null!;
        public string? Bio { set; get; } = "";
        public bool Verified { set; get; } = false;
        public bool IsAdmin { get; set; } = false;
        
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}