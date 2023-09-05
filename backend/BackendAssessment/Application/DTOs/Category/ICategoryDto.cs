namespace Application.DTOs.Category;

public interface ICategoryDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
}