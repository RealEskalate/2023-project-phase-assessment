using FluentValidation;
using Application.Persistence.Contracts;
using Application.DTOs.Users.Validations;
using Application.DTOs.User;

namespace Application.DTOs.Users.Validations
{
    public class ValidateUpdateUserDto:AbstractValidator<UpdateUserDto>
    {
        private readonly IUserRepository _userRepository;

        public ValidateUpdateUserDto(IUserRepository userRepository)
        {

        _userRepository = userRepository;
        Include(new IValidateUserDto());

        
        RuleFor(u => u.Id)
        .NotEmpty().WithMessage("{PropertyName} must required");
        // .MustAsync(async (id, token) =>
        // {
        //     var userIdExist = await _userRepository.Exists(id);
        //     return userIdExist;
        // })
        // .WithMessage("{PropertyName} does not exist.");
        }

        private void Include(IValidateUserDto validateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}