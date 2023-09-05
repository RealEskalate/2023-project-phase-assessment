using AutoMapper;
using MediatR;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Categories.Commands.Requests;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos.Validators;
using ProductHub.Domain.Entities;
using ProductHub.Application.DTOs.CategorydDtos.Validators;

namespace ProductHub.Application.Features.Categories.Commands.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var createValidator = new CreateCategoryDtoValidator();
        var validationResult = await createValidator.ValidateAsync(request.CreateCategoryDto);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            return CommonResponse<int>.FailureWithError("Category creation failed", errorMessages);
        }
        else
        {
            var category = _mapper.Map<Category>(request.CreateCategoryDto);
            var newCategory = await _unitOfWork.CategoryRepository.AddAsync(category);
            int success = await _unitOfWork.SaveAsync();

            if (success != 0)
            {
                return CommonResponse<int>.Success(newCategory.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Category Creation Failed");
            }
        }
    }
}
