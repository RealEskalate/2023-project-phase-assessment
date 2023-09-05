using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<bool> EmailExists(string email);
    Task<User> GetByUsername(string username);
    Task<bool> UsernameExists(string username);
}
