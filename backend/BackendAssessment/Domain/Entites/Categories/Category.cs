using Domain.Common.Models;

namespace Domain.Entites.Categories;

public class Category : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
}