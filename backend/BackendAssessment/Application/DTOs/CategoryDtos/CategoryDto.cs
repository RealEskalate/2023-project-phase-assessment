using ProductHub.Domain.Entities;

namespace ProductHub.Application.DTOs.CategoryDtos;
public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
