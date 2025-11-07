using ERP.CleanDemo.Domain.Entities;

namespace ERP.CleanDemo.Application.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task AddAsync(Category entity);
    Task UpdateAsync(Category entity);
    Task DeleteAsync(Category entity);
    Task<bool> ExistsAsync(int id);
}