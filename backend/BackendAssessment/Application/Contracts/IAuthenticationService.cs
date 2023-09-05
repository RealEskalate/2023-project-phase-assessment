using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(UserRegistrationDto userRegistrationDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);
    }
}
