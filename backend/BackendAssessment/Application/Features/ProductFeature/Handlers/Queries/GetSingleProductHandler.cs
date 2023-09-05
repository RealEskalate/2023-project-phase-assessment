using Application.Contracts;
using Application.DTO.ProductDTO.DTO;
using Application.Exceptions;
using Application.Features.ProductFeature.Requests.Queries;
using Application.Response;
using AutoMapper;
using MediatR;


namespace Application.Features.ProductFeature.Handlers.Queries
{
    public class GetSingleProductHandler : IRequestHandler<GetSingleProductQuery, BaseResponse<ProductResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSingleProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<ProductResponseDTO>> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.ProductRepository.Get(request.Id);
            if (result == null)
            {
                throw new NotFoundException("Product is not found");
            }

            var Product = _mapper.Map<ProductResponseDTO>(result);
            
            return new BaseResponse<ProductResponseDTO>{
                Success = true,
                Message = "Product is retrieved successfully",
                Value = Product
            };
            
        }
    }
}
