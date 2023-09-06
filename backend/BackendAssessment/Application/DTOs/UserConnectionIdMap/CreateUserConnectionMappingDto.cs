using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.UserConnectionIdMap
{
    public class CreateUserConnectionMappingDto
    {
        public Guid UserId { get; set; }
        public string ConnectionId { get; set; } = string.Empty;
    }
}