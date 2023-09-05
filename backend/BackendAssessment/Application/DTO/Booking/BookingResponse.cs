using Application.DTO.Common;
using Application.DTO.Product;
using Application.DTO.User;

namespace Application.DTO.Booking;

public class BookingResponse : BaseDto
{
    public DateTime EndDate { get; set; }
    public int ProductId { get; set; }
    public ProductResponseDto Product { get; set; } = null!;
    public int UserId { get; set; }
    public UserResponseDto User { get; set; } = null!;
    public int Count { get; set; }
}