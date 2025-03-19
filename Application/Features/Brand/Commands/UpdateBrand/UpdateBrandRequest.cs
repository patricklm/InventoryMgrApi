using System;
using MediatR;

namespace Application.Features.Brand.Commands.UpdateBrand;

public class UpdateBrandRequest:IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
