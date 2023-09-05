using Domain.Common;

namespace Domain.Entites;

public class User : BaseEntity
{
    public string Email { get; set; } = "";
    
    public string UserName { get; set; } = "";

    public byte[] PasswordHash { get; set; }
    public ICollection<Product> Products { get; set; }
}