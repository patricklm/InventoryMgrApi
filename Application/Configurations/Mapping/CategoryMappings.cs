using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.UdateCategory;
using Application.Features.Category.Queries;
using Domain;

namespace Application.Configurations.Mapping;

public static class CategoryMappings
{
    public static Category ToCategory(this CreateCategoryRequest request)
    {
        return new Category
        {
            Name = request.Name,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now

            // CreatedBy = 0,
            // ModifiedBy = 0
        };
    }

    public static Category ApplyChanges(this Category category, UpdateCategoryRequest request)
    {
        category.Name = request.Name;
        category.ModifiedDate = DateTime.Now;
        return category;

        // ModifiedBy = 0;
    }

    public static CategopryDto ToCategoryDto(this Category category)
    {
        return new CategopryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
