namespace BackendAssessment.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IProductRepository ProductRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task<int> SaveAsync();
}