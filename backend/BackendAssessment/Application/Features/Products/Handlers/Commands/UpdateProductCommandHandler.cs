using AutoMapper;
using MediatR;
using ProductHub.Application.Common.Responses;
using ProductHub.Application.Contracts.Persistence;
using ProductHub.Application.Features.Products.Requests.Commands;
using ProductHub.Domain.Entites;

namespace ProductHub.Application.Features.Products.Handlers.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, CommonResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommonResponse<int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken){
        
        var product = await _unitOfWork.ProductRepository.GetAsync(request.ProductUpdateDto.Id);

        if (product == null)
        {
           return CommonResponse<int>.Failure("Product Not Found");
        }

        _mapper.Map(request.ProductUpdateDto, product);
        await _unitOfWork.ProductRepository.UpdateAsync(product);
        await _unitOfWork.SaveAsync();

        return CommonResponse<int>.Success(product.Id);
    }
}
