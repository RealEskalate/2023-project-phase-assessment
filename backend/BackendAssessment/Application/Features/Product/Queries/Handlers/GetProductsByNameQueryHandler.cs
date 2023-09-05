
using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.DTOs.ProductDtos;
using ProductHub.Application.Features.Products.Queries.Requests;

namespace ProductHub.Application.Features.Products.Queries.Handlers;
public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, CommonResponse<List<ProductDto>>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GetProductsByNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CommonResponse<List<ProductDto>>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
    {
        CommonResponse<List<ProductDto>> response;
        response = CommonResponse<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(await _unitOfWork.ProductRepository.GetProductsByNameAsync(request.Name)));
        return response;
    }
}