using MediatR;

namespace Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsRequest:IRequest<IEnumerable<ProductDto>>
{

}
