using AutoMapper;
using MediatR;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Categories.Commands.Requests;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategoryDtos.Validators;
using ProductHub.Domain.Entities;

namespace ProductHub.Application.Features.Categories.Commands.Handlers;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var deleteCategoryValidator = new DeleteCategoryDtoValidator(_unitOfWork.CategoryRepository);
        var validationResult = await deleteCategoryValidator.ValidateAsync(request.DeleteCategoryDto);

        if (validationResult.IsValid)
        {
            var category = await _unitOfWork.CategoryRepository.GetAsync(request.DeleteCategoryDto.Id);
            await _unitOfWork.CategoryRepository.DeleteAsync(category);
            int success = await _unitOfWork.SaveAsync();
            if (success > 0)
            {
                return CommonResponse<int>.Success(category.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("product Deletion Failed");
            }
        }
        else
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            return CommonResponse<int>.FailureWithError("product Deletion Failed", errorMessages);
        }
    }
}
