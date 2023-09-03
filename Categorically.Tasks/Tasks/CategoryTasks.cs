using Categorically.DataAccess.Models;
using Categorically.Services;
using Microsoft.Extensions.Logging;

namespace Categorically.Tasks;

public class CategoryTasks : ICategoryTasks
{
    private readonly ICategoryService _categoryService;
    private readonly ILogger<CategoryTasks> _logger;

    public CategoryTasks(ICategoryService categoryService, ILogger<CategoryTasks> logger)
    {
        _categoryService = categoryService;
        _logger = logger;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        try
        {
            return await _categoryService.GetAllCategoriesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting all categories.");
            throw;
        }
    }

    public async Task InsertCategoryAsync(Category category)
    {
        try
        {
            await _categoryService.InsertCategoryAsync(category);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while inserting a category.");
            throw;
        }
    }

    public async Task<Category?> GetCategoryAsync(int categoryId)
    {
        try
        {
            return await _categoryService.GetCategoryAsync(categoryId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while getting category with ID {categoryId}.");
            throw;
        }
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        try
        {
            await _categoryService.UpdateCategoryAsync(category);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating category with ID {category.CategoryId}.");
            throw;
        }
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        try
        {
            await _categoryService.DeleteCategoryAsync(category);
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting category with ID {category.CategoryId}.");
            throw;
        }
    }
}
