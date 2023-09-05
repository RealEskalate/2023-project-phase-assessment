using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    
}