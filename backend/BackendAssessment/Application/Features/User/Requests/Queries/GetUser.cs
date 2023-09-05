using Application.DTO.UserDTO;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetUser : IRequest<BaseCommandResponse<UserDTO>>{
    public required int Id{ set; get; }
    
}