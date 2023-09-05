using Application.DTOs.User;
using Application.Responses;
using MediatR;

namespace Application.Features.User.Request.Queries;

public class GetUserProfileRequest : IRequest<BaseCommandResponse<UserProfileDto>>{
    public required int Id { set; get; }
    
}