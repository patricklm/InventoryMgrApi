using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<GetCategoryRequest, CategopryDto>
{
    public async Task<CategopryDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await uow.Categories.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Category), request.Id.ToString());

        return category.ToCategoryDto();
    }
}
