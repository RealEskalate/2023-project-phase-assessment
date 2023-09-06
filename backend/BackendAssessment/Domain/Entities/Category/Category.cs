using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities.Category
{
    public class Category : EntityBase
    {
        public Category()
        {
            Products = new HashSet<Domain.Entities.Product.Product>();
        }
       
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Domain.Entities.Product.Product> Products { get; set; }
        
    }
}
