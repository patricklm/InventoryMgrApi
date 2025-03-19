using System;
using Application.Features.Brand.Queries.GetAllBrands;
using MediatR;

namespace Application.Features.Brand.Queries.GetBrand;

public class GetBrandRequest(int id) : IRequest<BrandDto>
{
    public int Id { get; set; } = id;
}
