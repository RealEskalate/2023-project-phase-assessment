namespace Backend.Application.Common.Interface.Authentication
{
    public interface IJwtTokenValidation
    {
        bool ValidateToken(string token);
        Guid ExtractUserIdFromToken(string token);
        string ExtractEmailFromToken(string token);
    }
}