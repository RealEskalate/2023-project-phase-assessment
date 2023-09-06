using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.UserConnectionIdMap;

namespace Application.Contracts.Persisitence
{
    public interface IUserConnectionMapRepository
    {
        Task AddUserConnectionMappingAsync(Guid userId, string connectionId);
        Task<CreateUserConnectionMappingDto> GetUserConnectionMappingAsync(Guid userId);
        Task RemoveUserConnectionMappingAsync(Guid userId);
    }
}