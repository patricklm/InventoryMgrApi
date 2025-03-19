using Application.Features.Brand.Commands.CreateBrand;
using Application.Features.Brand.Commands.UpdateBrand;
using Application.Features.Brand.Queries.GetAllBrands;
using Domain;

namespace Application.Configurations.Mapping;

public static class BrandMappings
{
    public static Brand ToBrand(this CreateBrandRequest request)
    {
        return new Brand
        {
            Name = request.Name
        };
    }

    public static BrandDto ToBrandDto(this Brand brand)
    {
        return new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name
        };
    }

    public static Brand ApplyUpdates(this Brand brand, UpdateBrandRequest request)
    {
        brand.Name = request.Name;
        brand.ModifiedDate = DateTime.Now;
        return brand;
    }
}
