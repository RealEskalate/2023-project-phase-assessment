﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authentication
{
    public record LoginRequest(

         string Email,
         string Password
        );
    
}
