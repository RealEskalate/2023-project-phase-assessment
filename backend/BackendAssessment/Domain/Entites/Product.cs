using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Product : BaseEntity
    {

        public Product()
        {
            Bookings = new HashSet<ProductBooking>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }

        public int Available { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductBooking> Bookings { get; set; }

    }
}
