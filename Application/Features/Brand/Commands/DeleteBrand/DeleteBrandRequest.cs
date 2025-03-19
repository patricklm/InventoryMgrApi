using MediatR;

namespace Application.Features.Brand.Commands.DeleteBrand;

public class DeleteBrandRequest(int id) : IRequest
{
    public int Id { get; set; } = id;
}
