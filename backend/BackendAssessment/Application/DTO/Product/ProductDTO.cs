namespace Application.DTO;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Pricing { get; set; }
    public bool Availability { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
}