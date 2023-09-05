using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Booking
    {
        
        public  int Id  {set;get;}
        public  int ProductId  {set;get;}
        public  int UserId  {set;get;}
        public  DateTime StartDate  {set;get;}
        public  DateTime EndDate  {set;get;}

        public virtual required Product Product {set;get;}

        public virtual required User User {set; get;}
    }
}