
using Application.Dtos.Common;

namespace Application.Dtos.Category;

public class CategoryResponseDto : BaseDto
{
    public string Name { get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;

}