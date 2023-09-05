namespace Application.Models.Identity;

public class User
{
    public string Id { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string UserName { get; set; } = String.Empty;
    public DateTime? DateCreated { get; set; }

    
    }