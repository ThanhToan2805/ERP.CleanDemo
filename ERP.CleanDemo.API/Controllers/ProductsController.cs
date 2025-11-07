using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Contracts.DTOs;
using ERP.CleanDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ERP.CleanDemo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepo;
    private readonly ICategoryRepository _categoryRepo;

    public ProductsController(IProductRepository productRepo, ICategoryRepository categoryRepo)
    {
        _productRepo = productRepo;
        _categoryRepo = categoryRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok((await _productRepo.GetAllAsync()).Select(p => new ProductDto(p.Id, p.Name, p.Price, p.CategoryId)));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var p = await _productRepo.GetByIdAsync(id);
        return p == null ? NotFound() : Ok(new ProductDto(p.Id, p.Name, p.Price, p.CategoryId));
    }

    [HttpGet("byCategory/{categoryId}")]
    public async Task<IActionResult> GetByCategory(int categoryId) =>
        Ok((await _productRepo.GetByCategoryIdAsync(categoryId)).Select(p => new ProductDto(p.Id, p.Name, p.Price, p.CategoryId)));

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto dto)
    {
        // validate category exists
        if (!await _categoryRepo.ExistsAsync(dto.CategoryId)) return BadRequest($"Category {dto.CategoryId} not found.");

        var entity = new Product { Name = dto.Name, Price = dto.Price, CategoryId = dto.CategoryId };
        await _productRepo.AddAsync(entity);
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, new ProductDto(entity.Id, entity.Name, entity.Price, entity.CategoryId));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
    {
        if (id != dto.Id) return BadRequest();
        var existing = await _productRepo.GetByIdAsync(id);
        if (existing == null) return NotFound();
        if (!await _categoryRepo.ExistsAsync(dto.CategoryId)) return BadRequest($"Category {dto.CategoryId} not found.");

        existing.Name = dto.Name;
        existing.Price = dto.Price;
        existing.CategoryId = dto.CategoryId;
        await _productRepo.UpdateAsync(existing);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _productRepo.GetByIdAsync(id);
        if (entity == null)
            return NotFound();

        await _productRepo.DeleteAsync(entity);
        return NoContent();
    }
}