using Domain.Entities;

namespace Application.Contracts.Infrastructure;

public interface IJwtGenerator
{
    public string Generate(User user);
}
