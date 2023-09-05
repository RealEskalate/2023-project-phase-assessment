using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Features.Products.Requests.Queries;

namespace ProductHub.Application.Features.Products.Handlers.Queries;

public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest, CommonResponse<ProductDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductDetailRequestHandler(IUnitOfWork unitOfWork, IMapper mapper){
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<ProductDto>> Handle(
        GetProductDetailRequest request,
        CancellationToken cancellationToken
    )
    {
        var product = await _unitOfWork.ProductRepository.GetAsync(request.Id);
        if(product == null){
            return CommonResponse<ProductDto>.Failure("Product Not Found");
        }
        
        return CommonResponse<ProductDto>.Success( _mapper.Map<ProductDto>(product));
    }
}
