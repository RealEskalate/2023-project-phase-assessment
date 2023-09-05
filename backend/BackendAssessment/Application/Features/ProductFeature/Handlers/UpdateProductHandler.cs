using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.DTO.ProductDTO;
using Application.DTO.ProductDTO.Validators;
using Application.Exceptions;
using Application.Features.ProductFeature.Requests;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.ProductFeature.Handlers;


public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, BaseCommandResponse<ProductListDTO>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper){
        _unitOfWork = unitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<ProductListDTO>> Handle(UpdateProductRequest request, CancellationToken cancellationToken){
        try{
            var AuthResponse = await _authService.TokenValidator(request.Token);
            request.Update.UserId = AuthResponse.Id;

            var validator = new UpdateProductDTOValidator(_unitOfWork.ProductRepository, _unitOfWork.CategoryRepository, _authService);
            var validationResult = await validator.ValidateAsync(request.Update);
            if (!validationResult.IsValid) throw new ValidationException(validationResult);
            
            var product = await _unitOfWork.ProductRepository.Get(request.Update.Id);
            _mapper.Map(request.Update, product);
            await _unitOfWork.ProductRepository.Update(product);
            
            if (await _unitOfWork.Save() == 0)  throw new ServerErrorException("Something Went Wrong");
            return BaseCommandResponse<ProductListDTO>.SuccessHandler(_mapper.Map<ProductListDTO>(product));
        }
        catch(Exception e){
            return BaseCommandResponse<ProductListDTO>.FailureHandler(e);

        }
    }
}