using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Product
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Description {get; set;}
        public decimal Price {get; set;}

        public Category? Category {get; set;}
        public List<User>? Users {get; set;}
        public List<Booking> Bookings {get; set;}
        public int Quantity {get; set;}

    }
}