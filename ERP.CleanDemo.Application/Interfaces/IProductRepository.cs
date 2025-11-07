using ERP.CleanDemo.Domain.Entities;

namespace ERP.CleanDemo.Application.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
    Task AddAsync(Product entity);
    Task UpdateAsync(Product entity);
    Task DeleteAsync(Product entity);
    Task<bool> ExistsAsync(int id);
}