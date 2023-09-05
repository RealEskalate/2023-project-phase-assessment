using Application.Dtos.ProductDto;
using Application.Response;
using MediatR;

namespace Application.Features.Product.Requests.Commands;

public class CreateProductCommand : IRequest<BaseCommandResponse<int?>>
{
  public CreateProductDto CreateProduct { get; set; }
}