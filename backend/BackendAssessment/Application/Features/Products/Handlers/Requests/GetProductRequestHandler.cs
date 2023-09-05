using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Products.Dtos;
using Application.Features.Products.Queries.Requests;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handlers.Requests;

public class GetProductRequestHandler
    : IRequestHandler<GetProductRequest, CommonResponse<ProductDto>>
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<ProductDto>> Handle(
        GetProductRequest request,
        CancellationToken cancellationToken
    )
    {
      if (await _unitOfWork.ProductRepository.ExistsAsync(request.ProductId) == false) {
        return CommonResponse<ProductDto>.FailureWithError("Product cannot be retrieved.", "Product doesn't exist.");
      }
        return CommonResponse<ProductDto>.Success(_mapper.Map<ProductDto>(await _unitOfWork.ProductRepository.GetAsync(request.ProductId)));
    }
}
