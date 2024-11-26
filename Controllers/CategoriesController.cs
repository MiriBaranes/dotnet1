using Microsoft.AspNetCore.Mvc;
using dotnet1.Service;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [AllowAnonymous] 
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }
    [HttpGet("include")]
    [AllowAnonymous] 
    public async Task<IActionResult> GetAllWithProductsAsync()
    {
        var categories = await _categoryService.GetAllWithProductsAsync();
        return Ok(categories);
    }
}
