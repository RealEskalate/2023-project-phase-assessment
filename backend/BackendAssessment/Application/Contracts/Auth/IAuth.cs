using Application.DTOs.Auth;

namespace Application.Contracts.Auth;

public interface IAuth
{
    public Task<string> Login(AuthRequest authRequest);
}