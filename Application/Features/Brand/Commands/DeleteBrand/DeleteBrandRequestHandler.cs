using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Brand.Commands.DeleteBrand;

public class DeleteBrandRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<DeleteBrandRequest>
{
    public async Task Handle(DeleteBrandRequest request, CancellationToken cancellationToken)
    {
        var brand = await uow.Brands.GetByIdAsync(request.Id)
          ?? throw new Exception($"Brand with id {request.Id.ToString()} not found");

        uow.Brands.Remove(brand);
        var isDeleted = await uow.CompleteAsync();

        if (isDeleted == false)
            throw new Exception("Could not delete a brand");

    }
}
