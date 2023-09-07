using AutoMapper;
using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Category.Commands.Requests;
using BackendAssessment.Application.Features.Category.DTO.validator;

namespace BackendAssessment.Application.Features.Category.Commands.Handlers;

public class DeleteCategoryCommandHandler
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public DeleteCategoryCommandHandler
    (
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var response = new CommonResponse<int>();
        var Validator = new DeleteCategoryDtoValidator(_unitOfWork);

        var validationResult = await Validator.ValidateAsync(command.deleteCategoryDto);

        if (!validationResult.IsValid)
        {
            return CommonResponse<int>.FailureWithError(message: "failed to delete category",
                error: validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }

        else
        {
            var foundCategory = await _unitOfWork.CategoryRepository.GetAsync(command.deleteCategoryDto.Id);
            ;
            await _unitOfWork.CategoryRepository.DeleteAsync(
                foundCategory
            );
            if (await _unitOfWork.SaveAsync() > 0)
            {
                return CommonResponse<int>.Success(foundCategory.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Failed to Delete category");
            }
        }
    }
}