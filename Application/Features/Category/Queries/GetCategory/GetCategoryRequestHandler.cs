using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<GetCategoryRequest, CategopryDto>
{
    public async Task<CategopryDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await uow.Categories.GetByIdAsync(request.Id)
            ?? throw new Exception($"Category with id {request.Id} not found");

        return category.ToCategoryDto();
    }
}
