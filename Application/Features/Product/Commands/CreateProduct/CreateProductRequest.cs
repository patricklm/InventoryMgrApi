using Application.Features.Product.Queries;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductRequest : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Cost { get; set; }
    public int UnitsInStock { get; set; } = 0;
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
}
