using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Brand.Commands.CreateBrand;

public class CreateBrandRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<CreateBrandRequest, int>
{
    public async Task<int> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
    {
        // Validate request

        // Convert CreateBrandRequest to Brand entity
        var brand = request.ToBrand();

        // Save Brand entity to database
        uow.Brands.Add(brand);
        var isCreated = await uow.CompleteAsync();

        if (isCreated == false)
            throw new Exception("Brand could not be saved");

        // return the brandId
        return brand.Id;
    }
}
