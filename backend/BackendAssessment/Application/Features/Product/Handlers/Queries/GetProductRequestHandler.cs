using Application.Contracts;
using Application.DTO;
using Application.Exceptions;
using Application.Features.Product.Requests.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Product.Handlers.Queries;

public class GetProductRequestHandler : IRequestHandler<GetProductRequest, BaseCommandResponse<ProductDTO>>
{
    
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProductRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<BaseCommandResponse<ProductDTO>> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        try{
            var product = await _unitOfWork.productRepository.Get(request.ProductId);
            if (product == null){
                throw new NotFoundException(nameof(Domain.Entites.Product), request.ProductId);
            }
            return BaseCommandResponse<ProductDTO>.SuccessHandler(_mapper.Map<ProductDTO>(product));
        } catch(Exception ex){
            return BaseCommandResponse<ProductDTO>.FailureHandler(ex);
        }
    }
}