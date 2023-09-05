using BackendAssessment.Application.DTOs.CategoryDtos;
namespace BackendAssessment.Application.DTOs.ProductDtos;
public class ProductDto 
{
    public int UserId { set; get; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Detail {get; set;}
    public CategoryDto CategoryDto{get; set;}

}