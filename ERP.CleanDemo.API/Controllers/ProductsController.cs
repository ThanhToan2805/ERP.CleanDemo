using ERP.CleanDemo.Application.Requests.Products;
using ERP.CleanDemo.Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.CleanDemo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetProductByIdQuery(id));
        return result is null ? NotFound() : Ok(result);
    }

    // GET BY CATEGORY
    [HttpGet("byCategory/{categoryId}")]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        var result = await _mediator.Send(new GetProductsByCategoryQuery(categoryId));
        return Ok(result);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto dto)
    {
        var result = await _mediator.Send(new CreateProductCommand(dto));
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
    {
        if (id != dto.Id) return BadRequest("Mismatched ID");
        await _mediator.Send(new UpdateProductCommand(dto));
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }
}