using Domain.Entites;

namespace Application.Contracts
{
    public interface IBookingRepository
    {
        Booking? GetBookingById(int id);
        void AddBooking(Booking booking);
        Booking EditBooking(Booking booking);
        List<Booking> GetAllBookings();
        Task<bool> Exists(int id);
        
    }
}