using Application.DTO.Product;
using MediatR;

namespace Application.Features.Products.Request.Command
{
    public class UpdateProductCommand : IRequest<GetProductDTO>
    {
        public UpdateProductDTO updateProductDTO { get; set; }
    }
}