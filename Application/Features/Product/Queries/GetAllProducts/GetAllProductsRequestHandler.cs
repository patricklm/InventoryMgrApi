using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<GetAllProductsRequest, IEnumerable<ProductDto>>
{
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var products = await uow.Products.GetProductsWithDetailsAsync();
        return products.Select(p=>p.ToProductDto());
    }
}
// 082 044 1540