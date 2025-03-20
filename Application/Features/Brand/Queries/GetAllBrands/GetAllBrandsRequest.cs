using MediatR;

namespace Application.Features.Brand.Queries.GetAllBrands;

public class GetAllBrandsRequest : IRequest<IEnumerable<BrandDto>>
{

}
