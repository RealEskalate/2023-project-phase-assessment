using Application.DTO.CategoryDTO.DTO;
using FluentValidation;


namespace Application.DTO.CategoryDTO.validations
{
    public class CategoryCreateValidation : AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateValidation()
        {
            Include(new CommonCategoryValidation());
        }
    }
}
