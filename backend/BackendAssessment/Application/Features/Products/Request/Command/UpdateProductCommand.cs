using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Products.Request.Command
{
    public class UpdateProductCommand : IRequest<GetProductDto>
    {
        public UpdateProductDto updateProductDTO { get; set; }
    }
}