using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductRequestHander(
    IUnitOfWork uow
) : IRequestHandler<CreateProductRequest, int>
{
    public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        // Validate request
        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            throw new InputValidationException("Validation failed for creating new Member", validationResult.ToDictionary());
        }

        var brand = await uow.Brands.GetByIdAsync(request.BrandId)
            ?? throw new NotFoundException(nameof(Brand), request.BrandId.ToString());

        var category = await uow.Categories.GetByIdAsync(request.CategoryId)
            ?? throw new NotFoundException(nameof(Category), request.CategoryId.ToString());

        var product = request.ToProduct();
        product.Brand = brand;
        product.Category = category;

        uow.Products.Add(product);
        await uow.CompleteAsync();

        return product.Id;
    }
}
