using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryRequest:IRequest<int>
{
    public string Name { get; set; } = string.Empty;
}
