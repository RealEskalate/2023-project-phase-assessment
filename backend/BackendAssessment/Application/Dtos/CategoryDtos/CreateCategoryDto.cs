using Domain.Common;

namespace Application.Dtos.CategoryDtos;

public class CreateCategoryDto : ICategoryDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}