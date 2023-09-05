using Domain.Common;

namespace Domain.Entites;

public enum Role
{
    User,
    Admin
}

public class User : BaseEntity
{

    public string Email { get; set; }
    public string UserName { get; set; }
    
    public Role Role { get; set; } = Role.User;
    
}