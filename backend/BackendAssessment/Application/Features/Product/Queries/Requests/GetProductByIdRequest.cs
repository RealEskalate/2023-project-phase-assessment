using BackendAssessment.Application.Common.Responses;
using BackendAssessment.Application.Features.Product.DTO;
using MediatR;
using BackendAssessment.Domain.Entities;

namespace BackendAssessment.Application.Features.Product.Queries.Requests;

public class GetProductByIdRequest : IRequest<CommonResponse<CreateProductDto>>
{
    public int Id {get; set;}
}