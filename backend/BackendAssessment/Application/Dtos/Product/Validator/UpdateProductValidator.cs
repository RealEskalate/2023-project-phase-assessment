using Application.Contracts.persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Product.Validator
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        public UpdateProductValidator(IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;

            Include(new IProductValidator(_userRepository, _categoryRepository));
        }
    }
}
