
using Application.Contracts;
using Application.Response;
using MediatR;
using AutoMapper;
using Application.DTO.ProductDTO.DTO;
using Application.Features.ProductFeature.Requests.Queries;
namespace Application.Features.CategoryFeature.Handlers.Queries
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllProductsQuery, BaseResponse<List<ProductResponseDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetAllCategoryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<ProductResponseDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductRepository.GetAll(request.userId);
            return new BaseResponse<List<ProductResponseDTO>> {
                Success = true,
                Message = "Products are retrieved successfully",
                Value = _mapper.Map<List<ProductResponseDTO>>(result)
            };
        }
    }
}
