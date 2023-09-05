using Domain.Entities;

namespace Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    public Task<User?> GetUserByEmail(string email);
    public Task<IReadOnlyList<User>> SearchByUsername(string username);
    public Task<User?> GetUserByUsername(string username);

    public Task ChangeUserRole(User user, Roles role);
}