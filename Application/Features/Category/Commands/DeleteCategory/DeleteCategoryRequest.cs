using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryRequest(int id):IRequest
{
    public int Id { get; set; } = id;
}
