namespace Application.Dtos.Booking;

public class UpdateBookingDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime ReturnDate { get; set; }
}