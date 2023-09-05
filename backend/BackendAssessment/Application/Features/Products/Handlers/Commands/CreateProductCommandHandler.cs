using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Products.Requests.Commands;
using ProductHub.Domain.Entites;

namespace ProductHub.Application.Features.Products.Handlers.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CommonResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken){
        //remember to add validation
        var product = _mapper.Map<Product>(request.ProductCreateDto);
        product = await _unitOfWork.ProductRepository.AddAsync(product);

        if( await _unitOfWork.SaveAsync() == 0)
        {
            return CommonResponse<int>.Failure("Error While Saving Changes!");
        
        }

        return CommonResponse<int>.Success(product.Id);
    }
}
