using Application.Contracts.Persistence;
using Domain;
using Persistence.Contexts;

namespace Persistence.Repositories;

internal class CategoryRepository(InventoryContext context) : Repository<Category>(context), ICategoryRepository
{
    // use dbSet and Conext inherited from Repository<Category>
}
