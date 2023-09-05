
namespace Application.DTO.CategoryDTO.DTO
{
    public class CategoryResponseDTO : IBaseCategoryDTO
    {
        public int Id {set;get;}
        public string? Name {get; set;}
        public string? Description {get; set;}
    }
}
