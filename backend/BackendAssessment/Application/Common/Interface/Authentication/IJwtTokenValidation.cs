namespace Application.Common.Interface.Authentication
{
    public interface IJwtTokenValidation
    {
        bool ValidateToken(string token);
        int ExtractUserIdFromToken(string token);
        string ExtractEmailFromToken(string token);
    }
}