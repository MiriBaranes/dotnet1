namespace dotnet1.Service;
using dotnet1.Data;
using dotnet1.Entity;
using dotnet1.Repository;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddProductAsync(Product product)
    {
        await _repository.AddAsync(product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        await _repository.UpdateAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
