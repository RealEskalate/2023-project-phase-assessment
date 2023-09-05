using Application.Contracts;
using Application.Dtos.Booking;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Reposiotories;

public class BookingRepository : GenericReposiotry<Booking>,IBookingRepository
{   

    private readonly ProductHubDbContext _dbContext ;

    public BookingRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;

    }

    public async Task<List<BookingDto>> GetAllBookingsByUserIdAsync(int userId)
    {
        var bookings = await _dbContext.Set<Booking>().ToListAsync();
        return bookings.Where(b => b.UserId == userId).Select(b => new BookingDto
        {
            Id = b.Id,
            UserId = b.UserId,
            ProductId = b.ProductId,
            BookingDate = b.BookingDate,
        }).ToList();
    
    }
}