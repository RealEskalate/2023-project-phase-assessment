using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class ProductBooking : BaseEntity
    {
        public int ProductId { get; set; }

        public string UserId { get; set; }  

        public virtual User User { get; set; }

        public virtual Product Product { get; set; }


        public int Quantity { get; set; }

        

    }
}
