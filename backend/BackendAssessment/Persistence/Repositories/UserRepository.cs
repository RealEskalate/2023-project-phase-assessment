using Application.Contracts.Persistence;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Domain.Entities;
using BackendAssessment.Persistence.Repositories;
namespace Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AssessmentDbContext context) : base(context)
    {
    }
}