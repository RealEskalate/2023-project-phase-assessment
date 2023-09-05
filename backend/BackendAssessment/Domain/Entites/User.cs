using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entites
{
    public class User : IdentityUser
    {
        public string? UserName {get; set;}

        public string? Password {get; set;}

        public string? Email {get; set;}

        public List<Booking>? Bookings {set; get;}
    }
}