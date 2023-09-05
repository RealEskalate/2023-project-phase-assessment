using Application.Contracts;
using Application.Dto.Product;
using Application.Features.Product.Requests.Queries;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Queries;

public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, ProductDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public GetProductByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<ProductDto?> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
        return _mapper.Map<ProductDto?>(result);
    }
}
