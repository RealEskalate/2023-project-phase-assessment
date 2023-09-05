using Application.Contracts;
using Application.Exceptions;
using Application.Features.Product.Requests.Commands;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Comment.Handlers.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, BaseCommandResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _unitOfWork.productRepository.Get(request.ProductId);

            if (product == null) throw new NotFoundException(nameof(Domain.Entites.Product), request.ProductId);
            if (product.UserId != request.UserId) throw new BadRequestException("You cant delete this product");


            await _unitOfWork.productRepository.Delete(product);
            await _unitOfWork.Save();
            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value);

        }catch (Exception ex)
        {
            return BaseCommandResponse<Unit>.FailureHandler(ex);

        }
    }
}