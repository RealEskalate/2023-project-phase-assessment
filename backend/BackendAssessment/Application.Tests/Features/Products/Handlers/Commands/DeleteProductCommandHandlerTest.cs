using Application.Contracts.Persistence;
using Application.Features.Products.Handlers.Commands;
using Application.Features.Products.Queries.Commands;
using Application.Profiles;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.Products.Handlers.Commands;

public class DeleteProductCommandHandlerTest
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly IMapper _mapper;
    private DeleteProductCommandHandler _handler;

    public DeleteProductCommandHandlerTest()
    {
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();

        _handler = new DeleteProductCommandHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task Valid_DeleteProduct()
    {
        var validDeleteProductCommand = new DeleteProductCommand { ProductId = 1, UserId = 1 };

        var result = await _handler.Handle(validDeleteProductCommand, CancellationToken.None);

        result.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public async Task Invalid_DeleteProduct()
    {
        var invalidDeleteProductCommand = new DeleteProductCommand { ProductId = 99, UserId = 1 };

        var result = await _handler.Handle(invalidDeleteProductCommand, CancellationToken.None);

        result.IsSuccess.ShouldBeFalse();
    }
}
