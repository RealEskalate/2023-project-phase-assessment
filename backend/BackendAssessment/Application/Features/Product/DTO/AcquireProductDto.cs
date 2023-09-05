namespace BackendAssessment.Application.Features.Product.DTO;

public class AcquireProductDto
{
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int Available { get; set; }
}