
using Moq;
using ProductHub.Application.Contracts.Persistence;

namespace ProductHub.Application.Tests.Mocks;


public class MockUnitOfWork
{
    public static Mock<IUnitOfWork> GetMockUnitOfWork()
    {
        var unitOfWork = new Mock<IUnitOfWork>();

        var mockUserRepository = MockUserRepository.GetUserRepository();
        var mockProductRepository = MockProductRepository.GetProductRepository();
        var mockCategoryRepository = MockCategoryRepository.GetCategoryRepository();

        unitOfWork.Setup(uow => uow.UserRepository).Returns(UserRepository.Object);
        unitOfWork.Setup(uow => uow.ProductRepository).Returns(mockProductRepository.Object);
        unitOfWork.Setup(uow => uow.CategoryRepository).Returns(mockCategoryRepository.Object);
        unitOfWork.Setup(uow => uow.SaveAsync()).ReturnsAsync(1);

        return unitOfWork;
    }
}
