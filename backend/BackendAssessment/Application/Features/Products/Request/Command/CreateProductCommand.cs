using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Products.Request.Command
{
    public class CreateProductCommand : IRequest<GetProductDto>
    {
        public CreateProductDto createProductDTO { get; set; }
    }
}