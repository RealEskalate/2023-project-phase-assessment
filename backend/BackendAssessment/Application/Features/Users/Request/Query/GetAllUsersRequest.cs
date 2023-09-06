using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Request.Query
{
    public class GetAllUsersRequest : IRequest<List<GetUserDTO>>
    {
    }
}