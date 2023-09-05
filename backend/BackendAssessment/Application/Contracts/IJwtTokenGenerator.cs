
namespace Application.Contracts
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string userId);
    }
}
