
using System.Collections.Generic;
using Domain;

namespace Domain.Entites
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
