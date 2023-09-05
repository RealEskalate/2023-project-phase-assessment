using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(ProductHubDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Booking>> GetByUserId(int userId)
    {
        return await _dbSet.Where(b => b.UserId == userId).ToListAsync();
    }

    public async Task<IReadOnlyList<Booking>> GetByProduct(int productId)
    {
        return await _dbSet.Where(b => b.ProductId == productId).ToListAsync();
    }
}