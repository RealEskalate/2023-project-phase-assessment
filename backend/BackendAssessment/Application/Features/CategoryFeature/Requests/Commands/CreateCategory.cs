using Application.DTO.CategoryDTO.DTO;
using Application.Response;
using MediatR;


namespace Application.Features.CategoryFeature.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<BaseResponse<CategoryResponseDTO>>
    {
        public CategoryCreateDTO? NewCategoryData { get; set; }
    }
}
