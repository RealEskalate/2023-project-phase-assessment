using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Product.Price)
                .GreaterThan(0)
                .WithMessage("{PropertyName} Must Be Greater Than Zero");
            
            RuleFor(p => p.Product.Quantity)
                .GreaterThan(0)
                .WithMessage("{PropertyName} Must Be Greater Than Zero");

            RuleFor(p => p.Product.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is Required.");
            
            RuleFor(p => p.Product.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is Required.");
            
            RuleFor(p => p.Product.CategoryId)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is Required.")
                .MustAsync(CategoryMustExist)
                .WithMessage("{PropertyName} does not exist.");
        }

        private async Task<bool> CategoryMustExist(Guid id, CancellationToken arg2)
        {
            var leaveType = await _unitOfWork.CategoryRepository.Get(id);
            return leaveType != null;
        }
    }
}
