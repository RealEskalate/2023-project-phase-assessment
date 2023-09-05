using Application.DTOs.Category;
using Application.DTOs.Common;
using Application.DTOs.User;

namespace Application.DTOs.Product;

public class ProductResponseDto : BaseDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Pricing { get; set; }
    public bool Availability { get; set; } = true;
    public CategoryResponseDto Category { get; set; } = null!;
    public UserResponseDto ProductOwner { get; set; } = null!;
}