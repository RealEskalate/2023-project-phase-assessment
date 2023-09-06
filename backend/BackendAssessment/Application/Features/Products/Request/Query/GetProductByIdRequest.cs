using Application.DTO.Product;
using MediatR;

namespace Application.Features.Products.Request.Query
{
    public class GetProductByIdRequest : IRequest<GetProductDTO>
    {
        public Guid Id { get; set; }
    }
}