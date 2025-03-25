using FluentValidation;

namespace Application.Features.Product.Commands.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Product name is required")
            .MaximumLength(100);

            RuleFor(p => p.Cost).NotEmpty().WithMessage("Provide Cost price");
          
    }
}
