using Application.Contracts.Persistence;
using Domain.Entities;
using FluentValidation;

namespace Application.DTOs.Category.validators;

public class BaseCategoryDtoValidator : AbstractValidator<ICategoryDto>
{
    public BaseCategoryDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required");
        RuleFor(dto => dto.UserId)
            .MustAsync(async (userId, token) =>
            {
                var user = await unitOfWork.UserRepository.Get(userId);
                if (user == null)
                    return false;
                if (user.Role != Roles.Admin)
                    return false;

                return true;
            }).WithMessage("User must be an admin");
    }
}