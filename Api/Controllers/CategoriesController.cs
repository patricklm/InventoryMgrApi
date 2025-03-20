using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UdateCategory;
using Application.Features.Category.Queries;
using Application.Features.Category.Queries.GetAllCatetories;
using Application.Features.Category.Queries.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController(
    IMediator mediator
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategopryDto>>> GetCategories()
    {
        return Ok(await mediator.Send(new GetAllCategoriesRequest()));
    }

    [HttpGet("{categoryId:int}")]
    public async Task<ActionResult<CategopryDto>> GetCategory([FromRoute] int categoryId)
    {
        return Ok(await mediator.Send(new GetCategoryRequest(categoryId)));
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
    {
        var categoryId = await mediator.Send(request);
        return CreatedAtAction(nameof(GetCategory), new { categoryId }, null);
    }

    [HttpPut("{categoryId:int}")]
    public async Task<ActionResult> UpdateCategory([FromRoute] int categoryId, [FromBody] UpdateCategoryRequest request)
    {
        await mediator.Send(request);
        return NoContent();
    }

    [HttpDelete("{categoryId:int}")]
    public async Task<ActionResult> DeleteCategory([FromRoute] int categoryId)
    {
        await mediator.Send(new DeleteCategoryRequest(categoryId));
        return NoContent();
    }
}

