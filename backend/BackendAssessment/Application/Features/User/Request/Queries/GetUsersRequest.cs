using Application.DTOs.User;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetUsersRequest : IRequest<BaseCommandResponse<List<UserDto>>>{

}