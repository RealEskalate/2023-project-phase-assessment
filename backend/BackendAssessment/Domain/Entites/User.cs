using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        // Navigation property for User's product listings
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
