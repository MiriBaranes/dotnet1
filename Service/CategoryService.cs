namespace dotnet1.Service;
using dotnet1.Data;
using dotnet1.Dto;
using dotnet1.Entity;
using dotnet1.Repository;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _repository.AddAsync(category);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        await _repository.UpdateAsync(category);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
     public async Task<IEnumerable<CategoryDto>> GetAllWithProductsAsync(){
        return await _repository.GetAllWithProductsAsync();
    }
}
