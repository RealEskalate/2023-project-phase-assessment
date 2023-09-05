using Application.Contracts;
using AutoMapper;
using MediatR;
using Application.Exceptions;
using Application.Responses;
using Domain.Entites;
using Application.Features.Product.Requests.Commands;

namespace Application.Features.Comment.Handlers.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try 
        {
            

            var product = _mapper.Map<Domain.Entites.Product>(request.productDTO);
            var category = await _unitOfWork.categoryRepository.Get(request.productDTO.ProductId);
            
        

            await _unitOfWork.productRepository.Add(product);
           
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");
            return BaseCommandResponse<int>.SuccessHandler(product.ProductId);
        }
        catch (Exception ex) 
        {
            return BaseCommandResponse<int>.FailureHandler(ex);
        }
    }
}