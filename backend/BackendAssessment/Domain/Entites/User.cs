using Domain.Common;

namespace Domain.Entities;

public enum UserRole
{
    ADMIN,
    USER
}

public class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole Role { get; set; }

    public virtual ICollection<Product> Products { get; set; } = null!;
}
