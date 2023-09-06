using Domain.Entites;

namespace Application.Persistance.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetByEmail(string email);
        public Task<List<User>> GetByNameEmail(string email);
    }
}