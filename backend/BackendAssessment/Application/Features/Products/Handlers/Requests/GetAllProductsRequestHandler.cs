using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Products.Dtos;
using Application.Features.Products.Queries.Requests;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handlers.Requests;

public class GetAllProductsRequestHandler
    : IRequestHandler<GetAllProductsRequest, CommonResponse<List<ProductDto>>>
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllProductsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<List<ProductDto>>> Handle(
        GetAllProductsRequest request,
        CancellationToken cancellationToken
    )
    {
        return CommonResponse<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(await _unitOfWork.ProductRepository.GetAsync()));
    }
}
