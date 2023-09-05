using Application.Common.Responses;
using Application.Contracts.Persistence;
using Application.Features.Product.Queries.Commands;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Handlers.Commands;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, CommonResponse<int>>
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;

    public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<CommonResponse<int>> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        throw new NotImplementedException();
    }
}
