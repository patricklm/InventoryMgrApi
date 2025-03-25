using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Product.Queries.GetProductDetails;

public class GetProductDetailsRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<GetProductDetailsRequest, ProductDetailsDto>
{
    public async Task<ProductDetailsDto> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
    {
        var product = await uow.Products.GetProductDetailsByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Product), request.Id.ToString());

        return product.ToProductDetailsDto();
    }
}
