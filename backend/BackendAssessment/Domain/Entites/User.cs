using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entites
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

       public  ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public  ICollection<BookProduct> BookProducts { get; set; } = new HashSet<BookProduct>();
    }
}
