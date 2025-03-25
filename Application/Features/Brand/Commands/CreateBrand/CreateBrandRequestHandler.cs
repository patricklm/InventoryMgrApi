using Application.Configurations.Mapping;
using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Brand.Commands.CreateBrand;

public class CreateBrandRequestHandler(
    IUnitOfWork uow
) : IRequestHandler<CreateBrandRequest, int>
{
    public async Task<int> Handle(CreateBrandRequest request, CancellationToken cancellationToken)
    {
        // Validate request
        var validator = new CreateBrandRequestValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.IsValid == false)
        {
            throw new InputValidationException("Validation failed for creating new Member", validationResult.ToDictionary());
        }

        // Convert CreateBrandRequest to Brand entity
        var brand = request.ToBrand();

        // Save Brand entity to database
        uow.Brands.Add(brand);
        await uow.CompleteAsync();

        // return the brandId
        return brand.Id;
    }
}
