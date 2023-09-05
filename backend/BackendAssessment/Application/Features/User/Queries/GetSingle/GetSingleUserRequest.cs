using Application.Dtos.User;
using MediatR;

namespace Application.Features.User.Queries.GetSingle;

public class GetSingleUserRequest : IRequest<UserResponseDto>
{
    public Guid UserId { get; set; }
}