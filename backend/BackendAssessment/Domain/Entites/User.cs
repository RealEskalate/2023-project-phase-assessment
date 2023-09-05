using Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class User : IdentityUser
    {

        public User() { 
        
            Products = new HashSet<Product>();
            Bookings = new HashSet<ProductBooking>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }
     
        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<ProductBooking> Bookings { get; set; }
    }
}
