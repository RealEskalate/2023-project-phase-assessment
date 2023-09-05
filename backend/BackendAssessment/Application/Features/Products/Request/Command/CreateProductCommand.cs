using Application.DTO.Product;
using MediatR;

namespace Application.Features.Products.Request.Command
{
    public class CreateProductCommand : IRequest<GetProductDTO>
    {
        public CreateProductDTO createProductDTO { get; set; } = null!;
    }
}