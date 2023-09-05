using Domain.Common;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Salt { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int RoleId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = null!;
    public virtual Role Role { get; set; } = null!;
}
