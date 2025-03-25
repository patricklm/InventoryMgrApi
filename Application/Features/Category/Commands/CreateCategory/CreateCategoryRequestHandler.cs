using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<CreateCategoryRequest, int>
{
    public async Task<int> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        // Validate input data

        var category = request.ToCategory();
        uow.Categories.Add(category);
        await uow.CompleteAsync();
      
        return category.Id;
    }
}
