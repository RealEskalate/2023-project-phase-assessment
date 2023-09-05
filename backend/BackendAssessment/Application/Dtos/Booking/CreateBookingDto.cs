namespace Application.Dtos.Booking;

public class CreateBookingDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime ReturnDate { get; set; }
}