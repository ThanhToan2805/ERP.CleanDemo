using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Domain.Entities;
using ERP.CleanDemo.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.CleanDemo.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories
            .Include(c => c.Products) // Load cả Product
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories
            .Include(c => c.Products)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Category entity)
    {
        _context.Categories.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category entity)
    {
        _context.Categories.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Category entity)
    {
        _context.Categories.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Categories.AnyAsync(c => c.Id == id);
    }
}