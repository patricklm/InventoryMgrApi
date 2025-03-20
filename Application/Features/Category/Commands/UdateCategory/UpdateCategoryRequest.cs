using MediatR;

namespace Application.Features.Category.Commands.UdateCategory;

public class UpdateCategoryRequest:IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
