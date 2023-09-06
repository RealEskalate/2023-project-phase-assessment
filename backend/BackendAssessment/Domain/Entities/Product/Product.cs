using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities.Product
{
    public class Product : EntityBase
    {
        public Guid CategoryId { get; set; }
         public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Pricing { get; set; }
    public int Availability { get; set; }
    public required Domain.Entities.Category.Category Category { get; set; }
   
    }
}
