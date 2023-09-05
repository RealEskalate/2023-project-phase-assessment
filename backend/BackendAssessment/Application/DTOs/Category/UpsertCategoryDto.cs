using Application.Common.Dtos;

namespace Application.Features.Categories.Dtos;

public class UpsertCategoryDto : BaseDto
{
    public string Name { get; set; } = null!;
}
