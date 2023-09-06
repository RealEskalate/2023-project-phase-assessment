using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using Application.DTOs.Catergories;
using Application.Features.Categories.Request.Command;
using AutoMapper;
using ErrorOr;
using MediatR;
using Domain.Errors;
using Application.DTOs.Catergories.Validators;
using Domain.Entites;

namespace Application.Features.Categories.Handler.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ErrorOr<CategoryResponseDto>>
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUserRepository userRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<ErrorOr<CategoryResponseDto>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.UserId);

            // check if user exists
            if (user == null)
            {
                return Errors.User.UserNotFound;
            }

            //check if user is admin
            if (!user.IsAdmin)
            {
                return Errors.Auth.AdminAccessRequired;
            }

            // check if category already exists
            var category = await _categoryRepository.GetCategoryByName(request.CreateCategoryDto.Name);

            if (category != null)
            {
                return Errors.Category.DuplicateCategory;
            }

            var Validator = new CreateCategoryValidator();
            var result = Validator.Validate(request.CreateCategoryDto);

            if (!result.IsValid)
            {
                return Errors.Category.InvalidCategory;
            }

            var newCategory = _mapper.Map<Category>(request.CreateCategoryDto);

            var createdCategory = await _categoryRepository.AddCategory(newCategory);

            return _mapper.Map<CategoryResponseDto>(createdCategory);

        }
    }
}