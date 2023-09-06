using Domain.Entites;
namespace Application.Contracts;
public interface IUserRepository
{
    Task<User> GetUserByIdentifier(string identifier);
    Task<User> GetUserById(int id);
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserByUserName(string userName);
    Task<User> AddUser(User user);
    Task<User> UpdateUser(User user);
    Task<List<User>> GetAllUsers();
    Task<User> DeleteUser(User user);
    Task<bool> Exists(Guid id);
}
