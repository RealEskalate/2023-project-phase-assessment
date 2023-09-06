using Application.Contracts.persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product.Validator
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CreateProductValidator(IUserRepository userRepository, ICategoryRepository categoryRepository) 
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            Include( new IProductValidator(_userRepository, _categoryRepository) );
        }
    }
}
