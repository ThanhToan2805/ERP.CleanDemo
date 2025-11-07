using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Domain.Entities;
using ERP.CleanDemo.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.CleanDemo.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    public ProductRepository(ApplicationDbContext db) => _db = db;

    public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
    {
        await _db.Products.AddAsync(product, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await _db.Products.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _db.Products.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _db.Products.Include(p => p.Category).AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _db.Products.Include(p => p.Category).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

    public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId, CancellationToken cancellationToken = default) =>
        await _db.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category).AsNoTracking().ToListAsync(cancellationToken);

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
    {
        _db.Products.Update(product);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default) =>
        await _db.Products.AnyAsync(p => p.Id == id, cancellationToken);
}