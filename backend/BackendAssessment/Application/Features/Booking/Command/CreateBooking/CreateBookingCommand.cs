using Application.DTO.Booking;
using MediatR;

namespace Application.Features.Booking.Command.CreateBooking;

public class CreateBookingCommand : IRequest<BookingResponse>
{
  public  BookingDto BookingDto { get; set; } = null!;
}