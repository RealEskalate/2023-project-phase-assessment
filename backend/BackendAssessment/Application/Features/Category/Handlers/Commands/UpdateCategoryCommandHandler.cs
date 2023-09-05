using Application.Contracts.Persistence;
using Application.Dtos.CategoryDtos.Validator;
using Application.Exceptions;
using Application.Features.Category.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Category.Handlers.Commands;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse<Unit?>>
{   
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
            

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<Unit?>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try{
            var validator = new UpdateCategoryDtoValidator(_unitOfWork.CategoryRepository);
            var validationResult = await validator.ValidateAsync(request.updateCategory);
            if (!validationResult.IsValid){
                throw new ValidationException(validationResult);
            }

            var category = await _unitOfWork.CategoryRepository.Get(request.updateCategory.Id);
            var user = await _unitOfWork.UserRepository.Get(request.UserId);
            _mapper.Map(request.updateCategory, category);
            if (user.Role != Role.Admin)
            {
                throw new BadRequestException("You are Unauthtized to do this");
            }
                
            await _unitOfWork.CategoryRepository.Update(category);
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");

            return BaseCommandResponse<Unit?>.SuccessHandler(Unit.Value);
        }
        catch(Exception ex){
            return BaseCommandResponse<Unit?>.FailureHandler(ex);
        }
    }
}

