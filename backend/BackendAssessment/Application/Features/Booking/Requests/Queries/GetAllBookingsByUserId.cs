using Application.Dtos.Booking;
using MediatR;

namespace Application.Features.Booking.Queries;
    public class GetAllBookingsByUserIdQuery : IRequest<List<BookingDto>>
    {
        public int UserId { get; set; }
    }
