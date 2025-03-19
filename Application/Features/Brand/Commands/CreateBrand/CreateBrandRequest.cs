using System;
using MediatR;

namespace Application.Features.Brand.Commands.CreateBrand;

public class CreateBrandRequest : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
}

