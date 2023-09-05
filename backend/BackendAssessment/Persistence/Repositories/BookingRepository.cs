using Application.Contracts.Persistence;
using Application.Dtos.BookingDtos;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    private readonly ProductHubDbContext _dbContext;
    
    public BookingRepository(ProductHubDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public  async Task<BookingResponseDto> BookAProduct(BookingRequestDto bookingRequest, int Userid)
    {
        // var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == bookingRequest.ProductId);
        // var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Userid);
        // var booking = new Booking
        // {
        //     Product = product,
        //     User = user,
        //     UserId = Userid,
        //     ProductId = bookingRequest.ProductId,
        //     StartDate = bookingRequest.StartDate,
        //     EndDate = bookingRequest.EndDate,
        //     Quantity = bookingRequest.Quantity
        //     
        //
        // };
        throw new NotImplementedException();

    }
}