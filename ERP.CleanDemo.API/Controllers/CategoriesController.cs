using ERP.CleanDemo.Application.Requests.Categories;
using ERP.CleanDemo.Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ERP.CleanDemo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoriesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCategoriesQuery());
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateDto dto)
    {
        var result = await _mediator.Send(new CreateCategoryCommand(dto));
        return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CategoryUpdateDto dto)
    {
        if (id != dto.Id) return BadRequest("Mismatched ID");
        await _mediator.Send(new UpdateCategoryCommand(dto));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCategoryCommand(id));
        return NoContent();
    }
}