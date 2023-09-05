using Application.Common.Responses;
using Application.Features.Product.Dtos;
using MediatR;

namespace Application.Features.Product.Queries.Requests;

public class GetAllProductsRequest : IRequest<CommonResponse<List<ProductDto>>> { }
