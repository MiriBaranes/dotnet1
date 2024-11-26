
namespace dotnet1.Service;

using dotnet1.Dto;
using dotnet1.Entity;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
     Task<IEnumerable<CategoryDto>> GetAllWithProductsAsync();
}


