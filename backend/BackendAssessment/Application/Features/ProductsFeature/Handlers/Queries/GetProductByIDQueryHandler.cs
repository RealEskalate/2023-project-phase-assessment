using Application.Common;
using Application.Contracts;
using Application.DTO.Product.DTO;
using Application.Exceptions;
using Application.Features.ProductsFeature.Requests.Queries;
using AutoMapper;
using MediatR;


namespace Application.Features.ProductsFeature.Handlers.Queries
{
    public class GetProductByIDQueryHandler : IRequestHandler<GetProductByIdQuery, BaseResponse<ProductResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIDQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<ProductResponseDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {

            var exists = await _unitOfWork.ProductRepository.Exists(request.Id);
            if (! exists) 
            {
                throw new NotFoundException("Product with this Id doesn't exist");
            }

            var result = await _unitOfWork.ProductRepository.GetbyId(request.Id);

            return new BaseResponse<ProductResponseDTO>()
            {
                Success = true,
                Message = "Product is retrived successfully",
                Value = _mapper.Map<ProductResponseDTO>(result)
            };
        }
    }
}
