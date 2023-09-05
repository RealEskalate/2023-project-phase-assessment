using Application.DTOs.Product;
using MediatR;

namespace Application.Features.Products.Request.Query
{
    public class GetProductByIdRequest : IRequest<GetProductDto>
    {
        public Guid Id { get; set; }
    }
}