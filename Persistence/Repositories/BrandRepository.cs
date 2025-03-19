using Application.Contracts.Persistence;
using Domain;
using Persistence.Contexts;

namespace Persistence.Repositories;

internal class BrandRepository(InventoryContext context) : Repository<Brand>(context), IBrandRepository
{
    // use dbSet and Conext inherited from Repository<Brand>
}
