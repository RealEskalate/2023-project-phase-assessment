using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class User
    {
        public User() 
        { 
            products = new HashSet<Product>();
        }
        public Guid id { get; set; }

        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool isAdmin { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}
