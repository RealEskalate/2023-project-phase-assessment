using Application.Contracts.Common;
using Application.DTOs.User;
using Domain.Entites;

namespace Application.Contracts;

public interface IUserRepository : IGenericRepository<UserEntity>
{
    public Task<UserEntity?> GetUserByEmail(string email);
}