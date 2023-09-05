using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Entities.Common;

namespace Backend.Domain.Entities
{
    public class User : BaseEntity

    {
        public string FirstName { set; get; } = null!;
        public string LastName { set; get; } = null!;
        public string UserName { set; get; } = null!;
        public string Email { set; get; } = null!;
        public string? Password { set; get; }
        public string? Bio { set; get; } = "";
        public string? Picture  { set; get; } = "";
        public bool Verified { set; get; } = false;
        public string Role { set; get; } = null!;
        public ICollection<Product>? Products { get; set; }
    }
}