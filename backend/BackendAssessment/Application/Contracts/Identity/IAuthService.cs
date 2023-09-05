using Application.Model;


namespace Application.Contracts.Identity;

public interface IAuthService{
    Task<AuthResponse> Login(LoginRequest request);
    Task<AuthResponse> Register(RegisterRequest reqeuest);
    
    Task<AuthResponse> TokenValidator(string token);
    
    Task<string> GetUserRole(string token);

    // Task<bool> Update(UpdateUserDTO request, string prevEmail); 

}