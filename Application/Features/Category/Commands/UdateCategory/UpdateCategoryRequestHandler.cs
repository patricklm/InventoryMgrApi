using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Category.Commands.UdateCategory;

public class UpdateCategoryRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<UpdateCategoryRequest>
{
    public async Task Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        // Validate request payload

        var category = await uow.Categories.GetByIdAsync(request.Id)
            ?? throw new Exception($"Category with id {request.Id} not found");

        var updatedCategory = category.ApplyChanges(request);
        await uow.CompleteAsync();
    }
}
