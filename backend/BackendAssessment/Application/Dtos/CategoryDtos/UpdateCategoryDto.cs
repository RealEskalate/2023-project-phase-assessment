using Application.Dtos.Common;

namespace Application.Dtos.CategoryDtos;

public class UpdateCategoryDto : BaseDto, ICategoryDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}