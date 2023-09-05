using Application.Contracts.Persistence;
using Application.Dtos.UserDtos;
using Application.Model;

namespace Application.Contracts.Identity;

public interface IAuthService{
    Task<string> Login(AuthRequest request, IUserRepository userRepository);
    Task<bool?> Register(CreateUserDto reqeuest, IUserRepository userRepository);
    Task<bool> ChangeRole(string role);

}