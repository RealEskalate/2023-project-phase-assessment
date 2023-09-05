
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entites;

namespace ProductHub.Application
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int userId);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }
}
