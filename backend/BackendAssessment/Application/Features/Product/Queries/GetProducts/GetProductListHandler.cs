using Application.Contracts.Persistence;
using Application.DTOs.Product;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetProducts
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<ProductDetailsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductListHandler(IUnitOfWork unitOfWork,
             IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDetailsDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetProductWithDetails();
            var productDetailsDto = _mapper.Map<List<ProductDetailsDto>>(products);
            return productDetailsDto;
        }
    }
}
