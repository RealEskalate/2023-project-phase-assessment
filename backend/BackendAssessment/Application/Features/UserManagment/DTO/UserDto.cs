

namespace BackendAssessment.Application.DTOs.Authentication;

public class UserDto 
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    
}
