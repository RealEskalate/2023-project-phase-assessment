using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Auth;

public class LoginRequest
{
    public string? UserName { get; set; } = "";
    public string? Email { get; set; } = "";
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = null!;
}