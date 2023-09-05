using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Categories.Dtos.Validators;
using Application.Features.Categories.Queries.Commands;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categorys.Handlers.Commands;

public class UpdateCategoryCommandHandler
    : IRequestHandler<UpdateCategoryCommand, CommonResponse<Unit>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<Unit>> Handle(
        UpdateCategoryCommand request,
        CancellationToken cancellationToken
    )
    {
        var dtoValidator = new CategoryDtoValidator();
        var validationResult = dtoValidator.Validate(request.UpdateCategoryDto);

        if (validationResult.IsValid == false)
        {
            return CommonResponse<Unit>.FailureWithError(
                "Category updation failed.",
                validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            );
        }

        var createdCategory = _mapper.Map<Category>(request.UpdateCategoryDto);
        await _unitOfWork.CategoryRepository.UpdateAsync(
            request.UpdateCategoryDto.Id,
            createdCategory
        );

        if (await _unitOfWork.SaveAsync() > 0)
        {
            return new CommonResponse<Unit> { };
        }
        else
        {
            return CommonResponse<Unit>.Failure("Category creation failed.");
        }
    }
}
