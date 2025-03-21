using Application.Features.Product.Commands.CreateProduct;
using Application.Features.Product.Queries;
using Application.Features.Product.Queries.GetAllProducts;
using Application.Features.Product.Queries.GetProductDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController(
    IMediator mediator
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        return Ok(await mediator.Send(new GetAllProductsRequest()));
    }

    [HttpGet("{productId:int}")]
    public async Task<ActionResult<ProductDto>> GetProduct([FromRoute] int productId)
    {
        return Ok(await mediator.Send(new GetProductDetailsRequest(productId)));
    }


    [HttpPost]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var productId = await mediator.Send(request);
        return CreatedAtAction(nameof(GetProduct), new { productId }, null);
    }
}

