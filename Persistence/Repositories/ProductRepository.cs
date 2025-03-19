using Application.Contracts.Persistence;
using Domain;
using Persistence.Contexts;

namespace Persistence.Repositories;

internal class ProductRepository(InventoryContext context) : Repository<Product>(context), IProductRepository
{
    // use dbSet and Conext inherited from Repository<Product>
}
