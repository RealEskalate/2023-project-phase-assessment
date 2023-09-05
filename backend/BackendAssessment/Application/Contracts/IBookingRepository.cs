using Application.Dtos.Booking;
using Domain.Entities;

namespace Application.Contracts;
public interface IBookingRepository : IGenericRepository<Booking>{
    Task<List<BookingDto>> GetAllBookingsByUserIdAsync(int userId);

}