using Application.DTOs.Common;

namespace Application.DTOs.Category;

public class CategoryDto : GenericDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}