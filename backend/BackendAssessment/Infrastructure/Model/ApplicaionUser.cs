using Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicaionUser : IdentityUser{

    public virtual ICollection<Product> Products{ get; set; } = new HashSet<Product>();

}