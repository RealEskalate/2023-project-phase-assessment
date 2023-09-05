
using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.DTOs.User.Validator;
using Application.Exceptions;
using Application.Features.User.Request.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.User.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseCommandResponse<Unit?>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<BaseCommandResponse<Unit?>> Handle(UpdateUserCommand request, CancellationToken cancellationToken){

            try{
                var validator = new UpdateUserDtoValidator(_unitOfWork.UserRepository);
                var validationResult = await validator.ValidateAsync(request.UpdateUser, cancellationToken);
                if (!validationResult.IsValid){
                    throw new ValidationException(validationResult);
                }

                var user = await _unitOfWork.UserRepository.Get(request.UpdateUser.Id);
                _mapper.Map(request.UpdateUser, user);
                await _authService.Update(request.UpdateUser, user.Email);
                user = _mapper.Map<Domain.Entities.User>(request.UpdateUser);
                await _unitOfWork.UserRepository.Update(user);
                if (await _unitOfWork.Save() == 0) throw new ServerErrorException("Something went wrong");
                return BaseCommandResponse<Unit?>.SuccessHandler(Unit.Value);
            }
            catch(Exception ex){
                return BaseCommandResponse<Unit?>.FailureHandler(ex);

            }
        }
    }
}