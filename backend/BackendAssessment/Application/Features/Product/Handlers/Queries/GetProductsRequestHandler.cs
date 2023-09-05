using Application.Contracts;
using Application.Dto.Product;
using Application.Features.Product.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Queries;

public class GetProductsRequestHandler : IRequestHandler<GetProductsRequest, IReadOnlyList<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
        
    public GetProductsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyList<ProductDto>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ProductRepository.GetAllAsync();

        return _mapper.Map<IReadOnlyList<ProductDto>>(result);
    }
}