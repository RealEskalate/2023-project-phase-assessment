using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.ProductDTO;
using Application.Exceptions;
using Application.Features.CategoryFeature.Requests;
using Application.Features.ProductFeature.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.ProductFeature.Handlers;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, BaseCommandResponse<Category>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public GetCategoryByIdHandler(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper){
        _unitOfWork = unitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<Category>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken){
        try{
            var product = await _unitOfWork.ProductRepository.Get(request.Id);
            if (product == null) throw new NotFoundException(nameof(Product),"Product not found");
            return BaseCommandResponse<Category>.SuccessHandler(_mapper.Map<Category>(product));
            
        }
        catch(Exception e){
            return BaseCommandResponse<Category>.FailureHandler(e);
        }
    }
}