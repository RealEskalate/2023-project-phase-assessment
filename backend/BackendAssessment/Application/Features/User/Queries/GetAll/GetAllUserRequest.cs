using Application.Dtos.User;
using MediatR;

namespace Application.Features.User.Queries.GetAll;

public class GetAllUserRequest : IRequest<IReadOnlyList<UserResponseDto>>
{

}