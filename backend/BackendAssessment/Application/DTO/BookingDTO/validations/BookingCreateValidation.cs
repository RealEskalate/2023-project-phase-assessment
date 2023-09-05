using Application.DTO.BookingDTO.DTO;
using FluentValidation;


namespace Application.DTO.BookingDTO.validations
{
    public class BookingCreateValidation : AbstractValidator<BookingCreateDTO>
    {
        public BookingCreateValidation()
        {
            Include(new CommonBookingValidation());
        }
    }
}
