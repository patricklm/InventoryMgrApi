using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Brand.Queries.GetBrand;

public class GetBrandRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<GetBrandRequest, BrandDto>
{
    public async Task<BrandDto> Handle(GetBrandRequest request, CancellationToken cancellationToken)
    {
        var brand = await uow.Brands.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Brand), request.Id.ToString());

        return brand.ToBrandDto();
    }
}
