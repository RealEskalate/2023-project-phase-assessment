using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual  ICollection<Product> Products { get; set; }
    }
}
