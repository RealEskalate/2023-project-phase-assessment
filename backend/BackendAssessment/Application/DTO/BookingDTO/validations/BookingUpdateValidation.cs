using Application.DTO.BookingDTO.DTO;
using FluentValidation;

namespace Application.DTO.BookingDTO.validations
{
    public class BookingUpdateValidation : AbstractValidator<BookingUpdateDTO> 
    {
        public BookingUpdateValidation()
        {
            Include(new CommonBookingValidation());
        }
    }
}
