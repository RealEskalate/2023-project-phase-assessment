using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Category
    {
        public Guid Id { get; set; }
        public Category()
        {
            products = new HashSet<Product>();
        }
        public string name { get; set; }
        public string description { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}
