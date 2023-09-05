using Application.Contracts.persistence;
using Application.Features.Products.Request.Commands;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Commands
{
    internal class DeleteProductRequestHandler : IRequestHandler<DeleteProductRequest, Unit>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductRequestHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if (product != null)
            {
                await _productRepository.Delete(product);
            }
            return Unit.Value;
        }
    }
}
