using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using MediatR;

namespace Application.Features.Product.Queries.GetProductDetails;

public class GetProductDetailsRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<GetProductDetailsRequest, ProductDetailsDto>
{
    public async Task<ProductDetailsDto> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
    {
        var product = await uow.Products.GetProductDetailsByIdAsync(request.Id)
            ?? throw new Exception($"Product with id {request.Id} not found");

        return product.ToProductDetailsDto();
    }
}
