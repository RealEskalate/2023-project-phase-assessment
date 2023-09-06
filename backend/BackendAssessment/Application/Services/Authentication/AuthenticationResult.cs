using Application.DTOs.Users;

namespace Application.Services.Authentication;

public record AuthenticationResult(
    UserDto UserDto,
    string Token
);