﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class User : BaseEntity
    {
        public User()
        {
            product = new HashSet<Product>();
        }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public bool  IsAdmin { get; set; }


        public virtual ICollection<Product> product { get; set; }


    }
}
