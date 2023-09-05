using Backend.Application.DTOs.Users;

namespace Backend.Application.Services.Authentication;

public record AuthenticationResult(
    UserDto UserDto,
    string Token
);