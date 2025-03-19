using Domain.Common;

namespace Domain;

public class Brand : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Product> Products { get; } = [];
}
