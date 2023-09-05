using Domain.Entites;

namespace Application.Contracts.Persistance;

public abstract class IUserRepository : IGenericRepository<User>
{
    public Task<User> GetUserByEmail(string email);
    public Task<User> GetUserByUserName(string Username);
    
    public Task<List<User>> Search(string email, int pageNumber=0, int pageSize = 10);