using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Brand.Commands.DeleteBrand;

public class DeleteBrandRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<DeleteBrandRequest>
{
    public async Task Handle(DeleteBrandRequest request, CancellationToken cancellationToken)
    {
        var brand = await uow.Brands.GetByIdAsync(request.Id)
          ?? throw new NotFoundException(nameof(Brand), request.Id.ToString());

        uow.Brands.Remove(brand);
        var isDeleted = await uow.CompleteAsync();
    }
}
