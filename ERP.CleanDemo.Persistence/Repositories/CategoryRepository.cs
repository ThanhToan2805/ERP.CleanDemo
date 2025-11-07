using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Domain.Entities;
using ERP.CleanDemo.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.CleanDemo.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    public CategoryRepository(ApplicationDbContext db) => _db = db;

    public async Task AddAsync(Category category, CancellationToken cancellationToken = default)
    {
        await _db.Categories.AddAsync(category, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _db.Categories.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _db.Categories.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _db.Categories.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Category?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _db.Categories.Include(c => c.Products).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task UpdateAsync(Category category, CancellationToken cancellationToken = default)
    {
        _db.Categories.Update(category);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default) =>
        await _db.Categories.AnyAsync(c => c.Id == id, cancellationToken);
}