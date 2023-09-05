
using Domain.Entities;

namespace Application.DTOs.User;

public class UserProfileDto : BaseDto
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Roles Role { get; set; }
}