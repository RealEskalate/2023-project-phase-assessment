namespace Application.Dtos.BookingDtos;

public class BookingResponseDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}