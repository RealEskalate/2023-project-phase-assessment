using Backend.Domain.Entities;

namespace Backend.Application.Common.Interface.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(User user);
    string GenerateRecoveryToken(string email);
}