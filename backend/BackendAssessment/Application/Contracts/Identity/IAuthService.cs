using Application.Contracts.Persistence;
using Application.DTOs.User;
using Application.Model;
using Domain.Entities;

namespace Application.Contracts.Identity;

public interface IAuthService{
    Task<string> Login(AuthRequest request, IUserRepository userRepository);
    Task<bool?> Register(CreateUserDto request, IUserRepository userRepository);
    Task<bool> Update(UpdateUserDto request, string prevEmail); 

}