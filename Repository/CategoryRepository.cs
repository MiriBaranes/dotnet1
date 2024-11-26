namespace  dotnet1.Repository;

using AutoMapper;
using dotnet1.Data;
using dotnet1.Dto;
using dotnet1.Entity;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoryRepository(AppDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }
   public async Task<IEnumerable<CategoryDto>> GetAllWithProductsAsync()

    {
        var categories = await _context.Categories
        .Include(c => c.Products)
        .ToListAsync();

        var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return categoryDtos;
    }




    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await GetByIdAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
