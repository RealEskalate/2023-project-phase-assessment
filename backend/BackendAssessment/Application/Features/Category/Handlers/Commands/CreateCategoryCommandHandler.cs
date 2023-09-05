using Application.Contracts.Persistence;
using Application.Dtos.CategoryDtos.Validator;
using Application.Exceptions;
using Application.Features.Category.Requests.Commands;
using Application.Response;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Category.Handlers.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse<int?>>
{   
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<int?>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        try{
            var validator = new CreateCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCategory);
            if (!validationResult.IsValid){
                throw new ValidationException(validationResult);
            }
            
            var user = await _unitOfWork.UserRepository.Get(request.UserId);
            if (user.Role != Role.Admin)
            {
                throw new BadRequestException("You are Unauthtized to do this");
            }
            var category = _mapper.Map<Domain.Entites.Category>(request.CreateCategory);
            await _unitOfWork.CategoryRepository.Add(category);
            if (await _unitOfWork.Save() == 0) throw new ServerErrorException("Something Went Wrong");
            return BaseCommandResponse<int?>.SuccessHandler(category.Id);
        }
        catch(Exception ex){
            return BaseCommandResponse<int?>.FailureHandler(ex);
        }
    }
}
