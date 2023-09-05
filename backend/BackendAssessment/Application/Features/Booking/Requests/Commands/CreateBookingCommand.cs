using Application.Dtos.Booking;
using MediatR;

namespace Application.Features.Booking.Commands;
    public class CreateBookingCommand : IRequest<int>
    {
        public required CreateBookingDto CreateBookingDto { get; set; }
    }
