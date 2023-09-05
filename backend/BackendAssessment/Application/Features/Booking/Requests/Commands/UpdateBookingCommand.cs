using Application.Dtos.Booking;
using MediatR;

namespace Application.Features.Booking.Commands;
    public class UpdateBookingCommand : IRequest<int>
    {
        public required UpdateBookingDto UpdateBookingDto { get; set; }
    }
