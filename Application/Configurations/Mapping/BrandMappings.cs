using Application.Features.Brand.Commands.CreateBrand;
using Application.Features.Brand.Commands.UpdateBrand;
using Application.Features.Brand.Queries;
using Domain;

namespace Application.Configurations.Mapping;

public static class BrandMappings
{
    public static Brand ToBrand(this CreateBrandRequest request)
    {
        return new Brand
        {
            Name = request.Name,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now

            // CreatedBy = 0,
            // ModifiedBy = 0
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

    public static Brand ApplyChanges(this Brand brand, UpdateBrandRequest request)
    {
        brand.Name = request.Name;
        brand.ModifiedDate = DateTime.Now;
        return brand;

        // ModifiedBy = 0;
    }
}
