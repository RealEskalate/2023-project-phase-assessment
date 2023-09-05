using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UpdateProductCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Product", validationResult);
            
            var product = await _unitOfWork.ProductRepository.Get(request.Product.Id);
            
            if(product == null)
                throw new NotFoundException(nameof(Domain.Entites.Products.Product), request.Product.Id);
            
            if(_userService.UserId != product.UserId.ToString() && !await _userService.IsAdmin())
                throw new UnauthorizedAccessException("Not Authorized To Update Product");
            
            _mapper.Map(request.Product, product, typeof(UpdateProductCommand), typeof(Domain.Entites.Products.Product));
            
            await _unitOfWork.ProductRepository.Update(product);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
