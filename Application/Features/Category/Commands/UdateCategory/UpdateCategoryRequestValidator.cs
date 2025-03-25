using FluentValidation;

namespace Application.Features.Category.Commands.UdateCategory;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name should have 3 or more characters")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
    }
}
