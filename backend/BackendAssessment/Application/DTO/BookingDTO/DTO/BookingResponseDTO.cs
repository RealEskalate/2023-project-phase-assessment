using Domain.Entites;

namespace Application.DTO.BookingDTO.DTO
{
    public class BookingResponseDTO : IBaseBookingDTO
    {
        public  int Id  {set;get;}
        public  int ProductId  {set;get;}
        public  int UserId  {set;get;}
        public  DateTime StartDate  {set;get;}
        public  DateTime EndDate  {set;get;}

    }
}
