using MediatR;

namespace Application.Features.Category.Queries.GetCategory;

public class GetCategoryRequest(int id) : IRequest<CategopryDto>
{
    public int Id { get; set; } = id;
}
