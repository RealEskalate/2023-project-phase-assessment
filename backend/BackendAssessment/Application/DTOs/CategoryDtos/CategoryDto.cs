using ProductHub.Application.DTOs.Common;

namespace ProductHub.Application.DTOs.CategoryDtos;

public class CategoryDto : BaseDto, ICategoryDto
{
    public string Name {get; set;} = null!;
    public string Description {get; set;} = null!;
}
