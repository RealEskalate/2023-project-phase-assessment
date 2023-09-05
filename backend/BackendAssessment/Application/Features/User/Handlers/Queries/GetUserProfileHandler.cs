using Application.Contracts.Persistence;
using Application.DTOs.User;
using Application.Exceptions;
using Application.Features.User.Request.Queries;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class GetUserProfileHandler : IRequestHandler<GetUserProfileRequest, BaseCommandResponse<UserProfileDto>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetUserProfileHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<UserProfileDto>> Handle(GetUserProfileRequest request, CancellationToken cancellationToken){
        try{
            var user = await _unitOfWork.UserRepository.Get(request.Id);
            if (user is null){
                throw new NotFoundException(nameof(user), request.Id);
            }
            return BaseCommandResponse<UserProfileDto>.SuccessHandler(_mapper.Map<UserProfileDto>(user));
        }
        catch(Exception ex){
            return BaseCommandResponse<UserProfileDto>.FailureHandler(ex);
        }
    }
}