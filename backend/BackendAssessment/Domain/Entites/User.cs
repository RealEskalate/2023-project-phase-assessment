
using ProductHub.Domain.Common;

namespace ProductHub.Domain.Entities;
public class User : BaseEntity
{
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public virtual ICollection<Product> Products { get; set;} = new List<Product>();

}
