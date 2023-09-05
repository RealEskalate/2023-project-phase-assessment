using Application.Contracts;
using Application.Dtos.Booking;
using Application.Features.Booking.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Booking.Handlers.Queries;

public class GetAllBookingsByUserIdRequestHandler : IRequestHandler<GetAllBookingsByUserIdQuery, List<BookingDto>>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;

    public GetAllBookingsByUserIdRequestHandler(IBookingRepository bookingRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _mapper = mapper;
    }

    public async Task<List<BookingDto>> Handle(GetAllBookingsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var bookings = await _bookingRepository.GetAllBookingsByUserIdAsync(request.UserId);
        return _mapper.Map<List<BookingDto>>(bookings);
    }
}