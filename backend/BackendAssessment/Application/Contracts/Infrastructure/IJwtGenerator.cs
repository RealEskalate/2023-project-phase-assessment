using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Application.Contracts.Infrastructure;

public interface IJwtGenerator
{
    public string Generate(User user);
}