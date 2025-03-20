using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Brand.Queries.GetBrand;

public class GetBrandRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<GetBrandRequest, BrandDto>
{
    public async Task<BrandDto> Handle(GetBrandRequest request, CancellationToken cancellationToken)
    {
        var brand = await uow.Brands.GetByIdAsync(request.Id)
            ?? throw new Exception($"Brand with id {request.Id.ToString()} not found");

        return brand.ToBrandDto();
    }
}
