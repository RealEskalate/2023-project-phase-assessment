using Application.Contracts.Persistence;
using Application.Features.Product.Commands.CreateProduct;
using FluentValidation;

namespace Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Category.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} is required.");
                RuleFor(p => p.Category.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} is required.");
        }
        
    }
}
