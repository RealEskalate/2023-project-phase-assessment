using Application.DTOs.Common;

namespace Application.DTOs.Category;

public class CategoryResponseDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}