using Domain;

namespace Application.Contracts.Persistence;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsWithDetailsAsync();
    Task<Product?> GetProductDetailsByIdAsync(int id);
}
