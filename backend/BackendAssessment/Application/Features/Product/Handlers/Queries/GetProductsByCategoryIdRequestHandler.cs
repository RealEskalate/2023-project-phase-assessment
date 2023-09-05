using Application.Contracts;
using Application.Dto.Product;
using Application.Features.Product.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Queries;

public class GetProductsByCategoryIdRequestHandler : IRequestHandler<GetProductsByCategoryIdRequest, IReadOnlyList<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetProductsByCategoryIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyList<ProductDto>> Handle(GetProductsByCategoryIdRequest request, CancellationToken cancellationToken)
    {
        var results = await _unitOfWork.ProductRepository.GetProductsByCategoryIdAsync(request.CategoryId);
        
        return _mapper.Map<IReadOnlyList<ProductDto>>(results);
    }
}