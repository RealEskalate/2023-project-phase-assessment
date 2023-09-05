using Application.DTO.ProductDTO.DTO;
using Application.Response;
using MediatR;


namespace Application.Features.ProductFeature.Requests.Commands
{
    public class CreateProductCommand : IRequest<BaseResponse<ProductResponseDTO>>
    {
        public ProductCreateDTO? NewProductData { get; set; }
        public int userId { get; set; }
    }
}
