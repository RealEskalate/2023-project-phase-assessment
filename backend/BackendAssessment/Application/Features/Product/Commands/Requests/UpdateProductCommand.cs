using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Features.Product.DTO;
using MediatR;

namespace BackendAssessment.Application.Features.Product.Commands.Requests;

public class UpdateProductCommand: IRequest<CommonResponse<int>>
{
     public UpdateProductDto updateProductDto { get; set; }
}