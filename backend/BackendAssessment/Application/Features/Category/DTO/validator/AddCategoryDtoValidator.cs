using BackendAssessment.Application.Contracts.Persistence;
using FluentValidation;

namespace BackendAssessment.Application.Features.Category.DTO.validator;

public class AddCategoryDtoValidator: AbstractValidator<AddCategoryDto>
{
    private IUnitOfWork _unitOfWork;
    public AddCategoryDtoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
         RuleFor(x => x.ProductId)
         .MustAsync(
                async (id, token) =>
                {
                    var productExists = await _unitOfWork.ProductRepository.GetAsync(id);
                    return productExists != null;
                }
            )
            .WithMessage("{PropertyName} doesn't exist");
        
        RuleFor(x => x.CategoryId)
        .MustAsync(
            async (id, token) =>
            {
                var categoryExists = await _unitOfWork.CategoryRepository.GetAsync(id);
                return categoryExists != null;
            }
        );

    }
}