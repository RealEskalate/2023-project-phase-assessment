using Application.Contracts;
using Application.Exceptions;
using Application.Features.Product.Requests.Commands;
using Application.Responses;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateAvailablityCommand, BaseCommandResponse<Unit>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<Unit>> Handle(UpdateAvailablityCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var product = await _unitOfWork.productRepository.Get(request.productDTO.ProductId);
    

            _mapper.Map(request.productDTO, product);
            await _unitOfWork.productRepository.Update(product);

            if (await _unitOfWork.Save() == 0) throw new ServerErrorException("");


            return BaseCommandResponse<Unit>.SuccessHandler(Unit.Value);

        }
        catch (Exception ex)
        {
            return BaseCommandResponse<Unit>.FailureHandler(ex);
        }

    }
}