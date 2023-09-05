using Domain.Entities;

namespace Application.Contracts.Identity;
public interface IJwtGenerator
{
    Task<string> CreateToken(User user);
}