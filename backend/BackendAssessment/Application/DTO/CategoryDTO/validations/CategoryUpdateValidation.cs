using Application.DTO.CategoryDTO.DTO;
using FluentValidation;

namespace Application.DTO.CategoryDTO.validations
{
    public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateDTO> 
    {
        public CategoryUpdateValidation()
        {
            Include(new CommonCategoryValidation());
        }
    }
}
