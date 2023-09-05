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

public class CreateProductCommandHandlerTest
{
    private readonly IMapper _mapper;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private CreateProductCommandHandler _handler;

    public CreateProductCommandHandlerTest()
    {
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperConfig.CreateMapper();
        _mockUnitOfWork = MockUnitOfWork.GetMockUnitOfWork();
        _handler = new CreateProductCommandHandler(_mockUnitOfWork.Object, _mapper);
    }

    [Fact]
    public async Task Valid_CreateNewProduct()
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

        var createProductCommand = new CreateProductCommand
        {
            CreateProductDto = validProductDto,
            UserId = new Guid()
        };

        var result = await _handler.Handle(createProductCommand, CancellationToken.None);

        result.IsSuccess.ShouldBeTrue();
        result.Value.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Invalid_CreateNewProduct()
    {
        var invalidProductDto = new ProductDto {Name = null!,Price = 0, };

        var createProductCommand = new CreateProductCommand
        {
            UserId = new Guid(),
            CreateProductDto = invalidProductDto
        };

        var result = await _handler.Handle(createProductCommand, CancellationToken.None);

        result.IsSuccess.ShouldBeFalse();
    }
}
