using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Queries;
using Domain;

namespace Application.Configurations.Mapping;

public static class ProductMappings
{
    public static ProductDto ToProductDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            Cost = product.Cost,
            Price = product.Price,
            UnitsInStock = product.UnitsInStock,
            MinUnits = product.MinUnits,
            MaxUnits = product.MaxUnits,
            CategoryName = product.Category.Name,
            BrandName = product.Brand.Name,
            IsDiscontinued = product.IsDiscontinued
        };
    }

    public static ProductDetailsDto ToProductDetailsDto(this Product product)
    {
        return new ProductDetailsDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            Cost = product.Cost,
            Price = product.Price,
            UnitsInStock = product.UnitsInStock,
            MinUnits = product.MinUnits,
            MaxUnits = product.MaxUnits,
            CategoryName = product.Category.Name,
            BrandName = product.Brand.Name,
            IsDiscontinued = product.IsDiscontinued
            // more items here
        };
    }
    public static Product ToProduct(this CreateProductRequest request)
    {
        return new Product
        {
            Name = request.Name,
            Description = request.Description,
            UnitsInStock = request.UnitsInStock,
            Cost = request.Cost,
            Price = Product.SetPrice(request.Cost),

            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,

            // CreatedBy = 0,
            // ModifiedBy = 0
        };
    }
}
