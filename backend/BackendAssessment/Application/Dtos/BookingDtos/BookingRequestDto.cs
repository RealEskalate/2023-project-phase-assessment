
namespace Application.Dtos.BookingDtos;

public class BookingRequestDto 
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    
}