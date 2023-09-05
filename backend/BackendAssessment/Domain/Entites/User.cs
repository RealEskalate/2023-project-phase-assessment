namespace Domain.Entites;
public class User
{
    public int UserId { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public UserRole Role { get; set; }
    public List<Product> ?Products { get; set; }
}

public enum UserRole
{
    User,
    Admin
}