using Application.Contracts.persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product.Validator
{
    public class IProductValidator : AbstractValidator<IProductDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        public IProductValidator(IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            RuleFor(p => p.UserId)
                .MustAsync(async (id, token) =>
                {
                    var UserIdExists = await _userRepository.Exists(id);
                    return UserIdExists;
                })
               .WithMessage("{PropertyName} does not exist.");

            RuleFor(p=>p.CategoryId)
                .MustAsync(async (id, token) =>
                {
                    var CategoryIdExists = await _categoryRepository.Exists(id);
                    return CategoryIdExists;
                })
               .WithMessage("{PropertyName} does not exist.");

            RuleFor(p=>p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p=>p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Pricing)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }   
    }
}
