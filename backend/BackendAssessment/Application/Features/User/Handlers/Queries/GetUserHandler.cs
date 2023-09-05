using Application.Contracts.Identity;
using Application.Contracts;
using Application.DTO.UserDTO;
using Application.Exceptions;
using Application.Features.User.Request.Queries;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class GetUserHandler : IRequestHandler<GetUser, BaseCommandResponse<UserDTO>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<UserDTO>> Handle(GetUser request, CancellationToken cancellationToken){
        try{
            var user = await _unitOfWork.userRepository.Get(request.Id);
            if (user is null){
                throw new NotFoundException(nameof(user), request.Id);
            }
            return BaseCommandResponse<UserDTO>.SuccessHandler(_mapper.Map<UserDTO>(user));
        }
        catch(Exception ex){
            return BaseCommandResponse<UserDTO>.FailureHandler(ex);
        }
    }
}