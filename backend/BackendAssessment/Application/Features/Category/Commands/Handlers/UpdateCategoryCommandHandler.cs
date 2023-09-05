using AutoMapper;
using MediatR;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Categories.Commands.Requests;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.DTOs.CategorydDtos.Validators;
using ProductHub.Domain.Entities;
using ProductHub.Application.DTOs.CategoryDtos.Validators;

namespace ProductHub.Application.Features.Categories.Commands.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateCategoryCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var updateValidator = new UpdateCategoryDtoValidator(_unitOfWork.CategoryRepository);
        var validationResult = await updateValidator.ValidateAsync(request.UpdateCategoryDto);

        if (!validationResult.IsValid)
        {
            var errorMessages = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            return CommonResponse<int>.FailureWithError("Category creation failed", errorMessages);
        }
        else
        {
            var category = _mapper.Map<Category>(request.UpdateCategoryDto);
            var updatedCategory = await _unitOfWork.CategoryRepository.AddAsync(category);
            int success = await _unitOfWork.SaveAsync();

            if (success != 0)
            {
                return CommonResponse<int>.Success(updatedCategory.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Category Creation Failed");
            }
        }
    }
}
