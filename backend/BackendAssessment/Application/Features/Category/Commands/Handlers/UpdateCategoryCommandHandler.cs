using AutoMapper;
using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Contracts.Persistence;
using BackendAssessment.Application.Features.Category.Commands.Requests;
using BackendAssessment.Application.Features.Category.DTO.validator;
using MediatR;

namespace BackendAssessment.Application.Features.Category.Commands.Handlers;

public class UpdateCategoryCommandHandler: IRequestHandler<UpdateCategoryCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CommonResponse<int>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var response = new CommonResponse<int>();
        var Validator = new UpdateCategoryDtoValidator(_unitOfWork);

        var validationResult = await Validator.ValidateAsync(command.updateCategoryDto);

        if (!validationResult.IsValid)
        {
            return CommonResponse<int>.FailureWithError(message: "failed to update category",
                error: validationResult.Errors.Select(x => x.ErrorMessage).ToList());
        }
        else
        {
            var foundCategory = await _unitOfWork.CategoryRepository.GetAsync(command.updateCategoryDto.Id);
            _mapper.Map(command.updateCategoryDto, foundCategory);
            await _unitOfWork.CategoryRepository.UpdateAsync(
                foundCategory
            );
            if (await _unitOfWork.SaveAsync() > 0)
            {
                return CommonResponse<int>.Success(foundCategory.Id);
            }
            else
            {
                return CommonResponse<int>.Failure("Failed to update category");
            }
        }
    }
}