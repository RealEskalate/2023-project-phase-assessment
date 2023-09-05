using Domain.Common;

namespace Domain.Entites;


public class UserEntity : BaseDomainEntity
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool IsAdmin { get; set; } = false;
    public List<ProductEntity> Products { get; set; } = null!;
}