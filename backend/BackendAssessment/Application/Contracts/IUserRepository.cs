using Domain.Entites;

namespace Application.Contracts;

public interface IUserRepository : IGenericRepository<User>{
    public Task<User> GetUserByEmail(string email);
    public Task<User> GetUserByUserName(string email);

}