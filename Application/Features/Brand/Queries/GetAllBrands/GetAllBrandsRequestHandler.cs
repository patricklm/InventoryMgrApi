using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Brand.Queries.GetAllBrands;

public class GetAllBrandsRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<GetAllBrandsRequest, IEnumerable<BrandDto>>
{
    public async Task<IEnumerable<BrandDto>> Handle(GetAllBrandsRequest request, CancellationToken cancellationToken)
    {
        var brands = await uow.Brands.GetAllAsync();
        return brands.Select(b => b.ToBrandDto());
    }
}
