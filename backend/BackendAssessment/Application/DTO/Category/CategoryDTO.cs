using Application.DTO.Common;

namespace Application.DTO.Category
{
    public class CategoryDTO : BaseDTO
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}