using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

internal class InventoryContext(DbContextOptions<InventoryContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Product> Products { get; set; }
}
