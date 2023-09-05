using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAssessment.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string email {get; set;}

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }

    public virtual IEnumerable<Product> Products { get; set; }
}

