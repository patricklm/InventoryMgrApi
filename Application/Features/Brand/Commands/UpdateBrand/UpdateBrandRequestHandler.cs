using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Brand.Commands.UpdateBrand;

public class UpdateBrandRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<UpdateBrandRequest>
{
    public async Task Handle(UpdateBrandRequest request, CancellationToken cancellationToken)
    {
        var brand = await uow.Brands.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Brand), request.Id.ToString());

        brand.ApplyChanges(request);
        await uow.CompleteAsync();
    }
}
