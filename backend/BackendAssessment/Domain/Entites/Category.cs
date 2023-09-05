using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Category
    {
        public int Id {set;get;}
        public required string Name {get; set;}
        public required string Description {get; set;}

        public List<Product>? Products {get; set;}
    }
}