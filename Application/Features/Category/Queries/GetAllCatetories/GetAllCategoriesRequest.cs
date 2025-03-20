using MediatR;

namespace Application.Features.Category.Queries.GetAllCatetories;

public class GetAllCategoriesRequest:IRequest<IEnumerable<CategopryDto>>
{

}
