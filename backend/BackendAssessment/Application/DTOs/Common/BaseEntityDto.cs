﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Common
{
    public class BaseEntityDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

    }
}
