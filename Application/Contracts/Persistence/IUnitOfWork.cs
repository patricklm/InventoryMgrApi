namespace Application.Contracts.Persistence;

public interface IUnitOfWork
{
    IBrandRepository Brands { get; }
    ICategoryRepository Categories { get; }
    IProductRepository Products { get; }

    Task<bool> CompleteAsync();
}
