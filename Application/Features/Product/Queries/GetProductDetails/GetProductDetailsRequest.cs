using MediatR;

namespace Application.Features.Product.Queries.GetProductDetails;

public class GetProductDetailsRequest(int id) : IRequest<ProductDetailsDto>
{
    public int Id { get; set; } = id;
}
