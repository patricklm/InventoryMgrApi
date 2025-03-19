using Application.Contracts.Persistence;
using Persistence.Contexts;

namespace Persistence.Repositories;

internal class UnitOfWork(InventoryContext context) : IUnitOfWork, IDisposable
{
    private readonly InventoryContext _context = context;

    public IBrandRepository Brands { get; private set; } = new BrandRepository(context);

    public ICategoryRepository Categories { get; private set; } = new CategoryRepository(context);

    public IProductRepository Products { get; private set; } = new ProductRepository(context);

    public async Task<bool> CompleteAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
