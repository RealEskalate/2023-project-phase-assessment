using Application.Contracts.Persistence;
using Application.DTO.Booking;
using AutoMapper;
using MediatR;

namespace Application.Features.Booking.Command.CreateBooking;

public class CreateBookingCommandHandler  :IRequestHandler<CreateBookingCommand, BookingResponse>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;
    

    public CreateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }

    public Task<BookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}