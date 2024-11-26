
namespace dotnet1.Repository;

using dotnet1.Dto;
using dotnet1.Entity;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
    Task<IEnumerable<CategoryDto>> GetAllWithProductsAsync();
}


