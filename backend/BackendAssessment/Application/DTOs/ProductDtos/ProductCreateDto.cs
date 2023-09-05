namespace ProductHub.Application.DTOs.ProductDtos;

public class ProductCreateDto : IProductDto
{
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
    public int Price {get; set;}
    public int UserId {get; set;}
    public int CategoryId {get; set;}
    public bool Availability {get; set;}
}
