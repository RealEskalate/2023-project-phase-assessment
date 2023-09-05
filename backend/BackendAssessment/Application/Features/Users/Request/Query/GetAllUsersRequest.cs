using Application.DTOs.User;
using MediatR;

namespace Application.Features.Users.Request.Query
{
    public class GetAllUsersRequest : IRequest<List<GetUserDto>>
    {
    }
}