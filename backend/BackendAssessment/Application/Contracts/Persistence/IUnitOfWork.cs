namespace ProductHub.Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    IUserRepository UserRepository { get; }
    ICategoryRepository CategoryRepository { get; }

    Task<int> SaveAsync();
}
