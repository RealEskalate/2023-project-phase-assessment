namespace Application.DTOs.Category;

public class CreateCategoryDto : ICategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
}