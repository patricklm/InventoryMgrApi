using Application.Features.Brand.Commands.CreateBrand;
using Application.Features.Brand.Commands.DeleteBrand;
using Application.Features.Brand.Commands.UpdateBrand;
using Application.Features.Brand.Queries.GetAllBrands;
using Application.Features.Brand.Queries.GetBrand;
using Application.Features.Brand.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BrandsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
    {
        return Ok(await mediator.Send(new GetAllBrandsRequest()));
    }

    [HttpGet("{brandId:int}")]
    public async Task<ActionResult<BrandDto>> GetBrand([FromRoute] int brandId)
    {
        return Ok(await mediator.Send(new GetBrandRequest(brandId)));
    }

    [HttpPost]
    public async Task<ActionResult> CreateBrand([FromBody] CreateBrandRequest request)
    {
        var brandId = await mediator.Send(request);
        return CreatedAtAction(nameof(GetBrand), new { brandId }, null);
    }

    [HttpPut("{brandId}")]
    public async Task<ActionResult> UpdateBrand([FromRoute] int brandId, [FromBody] UpdateBrandRequest request)
    {
        await mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{brandId:int}")]
    public async Task<ActionResult> DeleteBrand([FromRoute] int brandId)
    {
        await mediator.Send(new DeleteBrandRequest(brandId));
        return NoContent();
    }
}

