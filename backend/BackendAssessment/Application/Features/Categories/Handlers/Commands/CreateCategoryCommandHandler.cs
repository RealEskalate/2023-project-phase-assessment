using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Categories.Dtos.Validators;
using Application.Features.Categories.Queries.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categorys.Handlers.Commands;

public class CreateCategoryCommandHandler
    : IRequestHandler<CreateCategoryCommand, CommonResponse<Guid>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<Guid>> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new CategoryDtoValidator();
        var validationResult = await dtoValidator.ValidateAsync(request.CreateCategoryDto);

        if (validationResult.IsValid == false)
        {
            return CommonResponse<Guid>.FailureWithError(
                "Category creation failed.",
                validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            );
        }

        if (await _unitOfWork.UserRepository.ExistsAsync(request.UserId))
        {
            return CommonResponse<Guid>.FailureWithError(
                "Category creation failed.",
                "User does not exist."
            );
        }

        var createdCategory = _mapper.Map<Category>(request.CreateCategoryDto);
        var category= await _unitOfWork.CategoryRepository.AddAsync(createdCategory);

        if (await _unitOfWork.SaveAsync() > 0)
        {
            return CommonResponse<Guid>.Success(category.Id);
        }
        else
        {
            return CommonResponse<Guid>.Failure("Category creation failed.");
        }
    }
}
