using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCatetories;

public class GetAllCategoriesRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<GetAllCategoriesRequest, IEnumerable<CategopryDto>>
{
    public async Task<IEnumerable<CategopryDto>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        var categories = await uow.Categories.GetAllAsync();
        return categories.Select(c => c.ToCategoryDto());
    }
}
