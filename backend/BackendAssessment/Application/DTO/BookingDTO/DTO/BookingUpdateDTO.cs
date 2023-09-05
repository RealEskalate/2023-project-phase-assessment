using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.BookingDTO.DTO
{
    public class BookingUpdateDTO : IBaseBookingDTO
    {
        public  int Id  {set;get;}
        public  int ProductId  {set;get;}
        public  int UserId  {set;get;}
        public  DateTime StartDate  {set;get;}
        public  DateTime EndDate  {set;get;}

    }
}
