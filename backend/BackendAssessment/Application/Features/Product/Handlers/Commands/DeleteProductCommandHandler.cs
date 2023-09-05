using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Product.Queries.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Commands;

public class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand, CommonResponse<Unit>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<CommonResponse<Unit>> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken
    )
    {
        throw new NotImplementedException();
    }
}
