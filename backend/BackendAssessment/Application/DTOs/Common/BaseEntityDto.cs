﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public class BaseEntityDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
