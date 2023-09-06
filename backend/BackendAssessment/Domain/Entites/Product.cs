using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Product
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double pricing { get; set; }
        public bool availability { get; set; }
        public virtual Category category { get; set; }
        public virtual User user { get; set; }
    }
}
