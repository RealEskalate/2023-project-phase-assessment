using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace Domain.Errors
{
    public static partial class Errors
    {
        public class Booking
        {
            public static Error BookingNotFound => Error.Validation(code: "BookingNotFound", description: "Booking not found");
            public static Error DuplicateBooking => Error.Conflict(code: "DuplicateBooking", description: "Booking already exists");
            public static Error InvalidBooking => Error.Validation(code: "InvalidBooking", description: "Invalid booking data");
        }
        
    }
}