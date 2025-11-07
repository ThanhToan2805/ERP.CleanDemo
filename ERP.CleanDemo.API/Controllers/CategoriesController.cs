using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Contracts.DTOs;
using ERP.CleanDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.CleanDemo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _repo;
    public CategoriesController(ICategoryRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok((await _repo.GetAllAsync()).Select(c => new CategoryDto(c.Id, c.Name)));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var c = await _repo.GetByIdAsync(id);
        return c == null ? NotFound() : Ok(new CategoryDto(c.Id, c.Name));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateDto dto)
    {
        var entity = new Category { Name = dto.Name };
        await _repo.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new CategoryDto(entity.Id, entity.Name));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CategoryUpdateDto dto)
    {
        if (id != dto.Id) return BadRequest();
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return NotFound();
        existing.Name = dto.Name;
        await _repo.UpdateAsync(existing);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!await _repo.ExistsAsync(id)) return NotFound();
        await _repo.DeleteAsync(id);
        return NoContent();
    }
}