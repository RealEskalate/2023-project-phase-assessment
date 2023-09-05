namespace Application.DTOs.Product.validators;

public interface IProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
}