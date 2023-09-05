using Application.Contracts.Persistence;
using Application.DTOs.User;
using Application.Exceptions;
using Application.Features.User.Request.Queries;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Queries;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, BaseCommandResponse<List<UserDto>>>{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper; 
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<List<UserDto>>> Handle(GetUsersRequest request, CancellationToken cancellationToken){
        var user = await _unitOfWork.UserRepository.GetAll();
        if (user == null){
            throw new NotFoundException(nameof(Domain.Entities.User), "User Not Found");
        }
        var userDto = _mapper.Map<List<UserDto>>(user);
        return BaseCommandResponse<List<UserDto>>.SuccessHandler(userDto);
    }
}