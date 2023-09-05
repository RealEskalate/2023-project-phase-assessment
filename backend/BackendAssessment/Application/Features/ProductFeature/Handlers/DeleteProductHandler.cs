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


public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, BaseCommandResponse<Unit>>{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;

    public DeleteProductHandler(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper){
        _unitOfWork = unitOfWork;
        _authService = authService;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse<Unit>> Handle(DeleteProductRequest request, CancellationToken cancellationToken){
        try{
            var AuthResponse = await _authService.TokenValidator(request.Token);
            var product = await _unitOfWork.ProductRepository.Get(request.ProductId);
            if (product == null) throw new NotFoundException(nameof(Product),"Product not found");
            if (product.UserId != AuthResponse.Id || AuthResponse.Role != "ADMIN") throw new BadRequestException("You are not allowed to do this operation");
            
            await _unitOfWork.ProductRepository.Delete(product);
            if (await _unitOfWork.Save() == 0)  throw new ServerErrorException("Something Went Wrong");
            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value);
        }
        catch(Exception e){
            return BaseCommandResponse<Unit>.FailureHandler(e);

        }
    }
}