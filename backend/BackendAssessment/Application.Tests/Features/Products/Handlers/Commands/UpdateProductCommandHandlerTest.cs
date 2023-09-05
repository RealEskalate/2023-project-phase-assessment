using Application.Contracts.Persistence;
using Application.Features.Categories.Dtos;
using Application.Features.Products.Dtos;
using Application.Features.Products.Handlers.Commands;
using Application.Features.Products.Queries.Commands;
using Application.Profiles;
using Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace Application.Tests.Features.Products.Handlers.Commands;

public class UpdateProductCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private UpdateProductCommandHandler _handler;

    public UpdateProductCommandHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new UpdateProductCommandHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task Valid_UpdateNewProduct()
    {
        var validProductDto = new ProductDto
        {
            Name = "Valid Product",
            Price = 100,
            Quantity = 10,
            UserId = new Guid(),
            Categories = new List<CategoryDto>
            {
                new CategoryDto { Name = "Category 1" },
                new CategoryDto { Name = "Category 2" }
            }
        };
        var updateProductCommand = new UpdateProductCommand
        {
            UserId = new Guid(),
            UpdateProductDto = validProductDto
        };

        var result = await _handler.Handle(updateProductCommand, CancellationToken.None);

        result.IsSuccess.ShouldBeTrue();
    }

    [Fact]
    public async Task Invalid_UpdateNewProduct()
    {
        var invalidProductDto = new ProductDto { Name = null, Price = 0, };

        var updateProductCommand = new UpdateProductCommand
        {
            UserId = new Guid(),
            UpdateProductDto = invalidProductDto
        };

        var result = await _handler.Handle(updateProductCommand, CancellationToken.None);

        result.IsSuccess.ShouldBeFalse();
    }
}
