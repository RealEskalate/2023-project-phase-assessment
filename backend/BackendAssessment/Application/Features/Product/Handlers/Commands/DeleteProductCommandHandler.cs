using Application.Contracts.Persistence;
using Application.Exceptions;
using Application.Features.Product.Requests.Commands;
using Application.Response;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Commands;

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
            var product = await _unitOfWork.ProductRepository.Get(request.Id);
            if (product == null) throw new NotFoundException(nameof(product), request.Id);
            if (product.UserId != request.UserId) throw new BadRequestException("You are Unauthtized to do this");
            await _unitOfWork.ProductRepository.Delete(product);
            int affectedRows = await _unitOfWork.Save();
            if (affectedRows == 0) throw new ServerErrorException("Something Went Wrong");

            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value);
            ;
        }
        catch (Exception ex)
        {
            return BaseCommandResponse<Unit>.FailureHandler(ex);
        }
    }

}