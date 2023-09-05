using Application.Contracts.Persistance;
using Application.DTO.UserDTO;
using Application.Model;
using Domain.Entites;

namespace Application.Contracts.Identity;

public interface IAuthService
{
    Task<string> Login(AuthRequest request, IUserRepository userRepository);
    Task<bool?> Register(CreateUserDto reqeuest, IUserRepository userRepository);
    Task<bool> Update(UpdateUserDTO request, string prevEmail);

}