
using Application.DTOs.User;
using Application.Responses;
using MediatR;
namespace Application.Features.User.Request;

public class SearchUsersRequest : IRequest<BaseCommandResponse<List<UserDto>>>{
    public string Query{ get; set; }

}