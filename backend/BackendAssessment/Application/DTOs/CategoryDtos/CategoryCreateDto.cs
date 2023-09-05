using ProductHub.Application.DTOs.CategoryDtos;

namespace ProductHub.Application.DTOs.CategoryDtos;

public class CategoryCreateDto : ICategoryDto
{
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
}
