using ProductHub.Domain.Entites;

namespace ProductHub.Application.Contracts.Infrastructure;

public interface IJwtGenerator
{
    public string Generate(User user);
}
