using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts.Common
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(User user);
    }
}
