using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.DTOs.Product;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Queries.GetProductDetail
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailQuery, ProductDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
   

        public GetProductDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
        }
        public async Task<ProductDetailsDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetProductWithDetails(request.Id);
            
            if (product == null)
                throw new NotFoundException(nameof(Domain.Entites.Products.Product), request.Id);
            
            var productDetailsDto = _mapper.Map<ProductDetailsDto>(product);
            return productDetailsDto;
        }
    }
}
