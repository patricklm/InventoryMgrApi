using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Brand.Commands.UpdateBrand;

public class UpdateBrandRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<UpdateBrandRequest>
{
    public async Task Handle(UpdateBrandRequest request, CancellationToken cancellationToken)
    {
        var brand = await uow.Brands.GetByIdAsync(request.Id)
            ?? throw new Exception($"Band with id {request.Id} not found");

        brand.ApplyUpdates(request);
        await uow.CompleteAsync();
    }
}
