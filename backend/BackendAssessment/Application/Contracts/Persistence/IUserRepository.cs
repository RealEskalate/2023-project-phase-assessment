using ProductHub.Application.Contracts.Persistence;
using ProductHub.Domain.Entites;

namespace Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<bool> UsernameExists(string username);
    public Task<bool> EmailExists(string email);
    public Task<User> GetByUsername(string username);

}
