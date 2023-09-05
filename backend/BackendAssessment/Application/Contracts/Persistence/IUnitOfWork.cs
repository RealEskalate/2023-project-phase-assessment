namespace Application.Contracts.Persistence;

public interface IUnitOfWork : IDisposable
{
    public IProductRepository ProductRepository { get; }
    public IUserRepository UserRepository { get; }
    public ICategoryRepository CategoryRepository { get; }

    public Task<int> SaveAsync();
}
