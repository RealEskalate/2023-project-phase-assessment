using ProductHub.Domain.Entities;

namespace ProductHub.Application.DTOs.CategoryDtos;
public class CreateCategoryDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

}