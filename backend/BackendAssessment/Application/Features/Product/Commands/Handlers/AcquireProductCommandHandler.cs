using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Features.Product.Commands.Requests;
using MediatR;

namespace BackendAssessment.Application.Features.Product.Commands.Handlers;

public class AcquireProductCommandHandler:  IRequestHandler<AcquireProductCommand, CommonResponse<int>>
{
    public Task<CommonResponse<int>> Handle(AcquireProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}