using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}