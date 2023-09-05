using Application.Dtos.Common;

namespace Application.Dtos;

public class CategoryDto : BaseDto
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;
}