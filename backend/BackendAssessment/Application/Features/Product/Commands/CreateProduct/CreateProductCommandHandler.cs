using Application.Contracts.Identity;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public CreateProductCommandHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            this._userService = userService;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            
            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Product", validationResult);
            
            var product = _mapper.Map<Domain.Entites.Products.Product>(request.Product);
            product.UserId = new Guid(_userService.UserId);
            
            await _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
