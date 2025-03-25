using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using Application.Exceptions;
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
            ?? throw new NotFoundException(nameof(Category), request.Id.ToString());

        var updatedCategory = category.ApplyChanges(request);
        await uow.CompleteAsync();
    }
}
