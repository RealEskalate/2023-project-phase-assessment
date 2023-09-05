using Application.Dtos.ProductDto;
using Application.Response;
using MediatR;

namespace Application.Features.Product.Requests.Commands;

public class UpdateProductCommand : IRequest<BaseCommandResponse<Unit?>>
{
    public UpdateProductDto updateProduct { get; set; }
    public int UserId { get; set; }
}