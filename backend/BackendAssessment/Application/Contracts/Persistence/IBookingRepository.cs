using Application.Dtos.BookingDtos;
using Domain.Entites;

namespace Application.Contracts.Persistence;

public interface IBookingRepository : IGenericRepository<Booking>
{
    public Task<BookingResponseDto> BookAProduct(BookingRequestDto bookingRequest, int UserId);
}