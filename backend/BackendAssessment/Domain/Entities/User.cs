using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public enum Roles
{
    Admin,
    User
}

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Roles Role { get; set; } = Roles.User;

    public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    public virtual IEnumerable<Category> Categories { get; set; } = new List<Category>();
}
