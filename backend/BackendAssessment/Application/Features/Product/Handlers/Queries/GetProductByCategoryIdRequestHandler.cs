using Application.Contracts;
using Application.DTO;
using Application.Exceptions;
using Application.Features.Product.Requests.Queries;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Product.Handlers.Queries;

public class GetProductByCategoryIdRequestHandler : IRequestHandler<GetProductByCategoryIdRequest, BaseCommandResponse<List<ProductDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public GetProductByCategoryIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<BaseCommandResponse<List<ProductDTO>>> Handle(GetProductByCategoryIdRequest request, CancellationToken cancellationToken)
    {
        try{
            var products =
                await _unitOfWork.productRepository.GetProducts(request.CategoryId);

            if (products == null){
                throw new NotFoundException(nameof(Domain.Entites.Product), request.CategoryId);
            }

            return BaseCommandResponse<List<ProductDTO>>.SuccessHandler(_mapper.Map<List<ProductDTO>>(products));
        }
        catch(Exception ex){
                return BaseCommandResponse<List<ProductDTO>>.FailureHandler(ex);
        }
    }
}