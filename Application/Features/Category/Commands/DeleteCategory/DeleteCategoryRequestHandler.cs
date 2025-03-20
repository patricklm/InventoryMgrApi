using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryRequestHandler(
    IUnitOfWork uow
    ) : IRequestHandler<DeleteCategoryRequest>
{
    public async Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await uow.Categories.GetByIdAsync(request.Id)
            ?? throw new Exception($"Category with id {request.Id} not found");

        uow.Categories.Remove(category);
        await uow.CompleteAsync();
    }
}
