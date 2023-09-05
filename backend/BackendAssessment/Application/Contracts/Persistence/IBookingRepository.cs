using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IBookingRepository : IGenericRepository<Booking>
{
    public Task<IReadOnlyList<Booking>> GetByUserId(int userId);
    public Task<IReadOnlyList<Booking>> GetByProduct(int productId);
}