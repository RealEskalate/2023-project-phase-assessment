namespace ProductHub.Application.DTOs.ProductDtos;

public interface IProductDto
{
    public string Name {get; set;}
    public string Description {get; set;}
    public int Price {get; set;}
    public int UserId {get; set;}
    public int CategoryId {get; set;}
    public bool Availability {get; set;}
}
