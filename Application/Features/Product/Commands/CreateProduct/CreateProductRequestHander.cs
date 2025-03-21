using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using Application.Features.Product.Queries;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductRequestHander(
    IUnitOfWork uow
) : IRequestHandler<CreateProductRequest, int>
{
    public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        // Validate request

        var brand = await uow.Brands.GetByIdAsync(request.BrandId)
            ?? throw new Exception($"Brand with id {request.BrandId} not found");

        var category = await uow.Categories.GetByIdAsync(request.CategoryId)
            ?? throw new Exception($"Category with id {request.CategoryId} not found");

        var product = request.ToProduct();
        product.Brand = brand;
        product.Category = category;

        uow.Products.Add(product);
        var isCreated = await uow.CompleteAsync();

        if (isCreated == false)
        {

        }

        return product.Id;
    }
}
