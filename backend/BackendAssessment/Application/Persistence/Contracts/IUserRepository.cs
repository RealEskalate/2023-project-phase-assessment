using Backend.Domain.Entities;

namespace Backend.Application.Persistence.Contracts;
public interface IUserRepository
{
    User? GetUserByIdentifier(string identifier);   
    User? GetUserById(Guid id);
    User? GetUserByEmail(string email);
    User? GetUserByUserName(string userName);
    void AddUser(User user);
    User EditUser(User user);
    List<User> GetAllUsers();
    Task<bool> Exists(Guid id);
    Task<bool> SetRole(Guid id, string role);
}
