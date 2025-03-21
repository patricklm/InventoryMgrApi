namespace Application.Features.Product.Queries;

public class ProductDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public int UnitsInStock { get; set; }
    public int MinUnits { get; set; }
    public int MaxUnits { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public bool IsDiscontinued { get; set; }
}
