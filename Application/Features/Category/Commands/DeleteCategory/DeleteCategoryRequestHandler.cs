using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryRequestHandler(
    IUnitOfWork uow
    ) : IRequestHandler<DeleteCategoryRequest>
{
    public async Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await uow.Categories.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Category), request.Id.ToString());

        uow.Categories.Remove(category);
        await uow.CompleteAsync();
    }
}
