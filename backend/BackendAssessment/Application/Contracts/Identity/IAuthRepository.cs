namespace Application.Contracts.Identity;

public interface IAuthRepository
{
    Task<string> RegisterAsync(string email, string password, string username);
    Task<string> LoginAsync(string email, string password);

}