namespace Application.Contracts.Persistence;

public interface IUnitOfWork
{ 
    ICategoryRepository CategoryRepository { get; }
    IProductRepository ProductRepository { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
    
    
}