using Application.Contracts.persistence;
using Application.Dtos.Product.Validator;
using Application.Exceptions;
using Application.Features.Products.Request.Commands;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handler.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IUserRepository userRepository, ICategoryRepository categoryRepository, IMapper mapper, IProductRepository product)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _productRepository = product;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var ProductToBeUpdated = await _productRepository.GetById(request.UpdateProductDto.Id);
            var validation = new UpdateProductValidator(_userRepository, _categoryRepository);
            var validationResult = await validation.ValidateAsync(request.UpdateProductDto, cancellationToken);
            if (validationResult.IsValid == true)
            {
                _mapper.Map(request.UpdateProductDto, ProductToBeUpdated);
                await _productRepository.Update(ProductToBeUpdated);
            }
            else
            {
                throw new ValidationException(validationResult);
            }
            return Unit.Value;
        }
    }
}
