using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

internal class ProductRepository(InventoryContext context) : Repository<Product>(context), IProductRepository
{
    public async Task<Product?> GetProductDetailsByIdAsync(int id)
    {
        return await dbSet.Include(p => p.Brand).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
    }

    // use dbSet and Conext inherited from Repository<Product>
    public async Task<IEnumerable<Product>> GetProductsWithDetailsAsync()
    {
        return await dbSet.Include(p => p.Brand).Include(p => p.Category).ToListAsync();
    }
}
