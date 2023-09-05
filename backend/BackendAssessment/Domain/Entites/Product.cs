using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Product : BaseEntity
    {

        public int Price { get; set; }

        public int Quantity { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public  Category Category { get; set; }

        
        [ForeignKey("User")]
        public string UserId { get; set; }
        public  User User { get; set; }
    }
}
