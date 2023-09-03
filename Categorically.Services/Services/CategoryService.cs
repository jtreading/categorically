using Categorically.DataAccess;
using Categorically.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Categorically.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDBContext _appDBContext;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(AppDBContext appDBContext, ILogger<CategoryService> logger)
    {
        _appDBContext = appDBContext;
        _logger = logger;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        try
        {
            return await _appDBContext.Categories.Include(c => c.User).ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while fetching all categories.");
            throw;
        }
    }

    public async Task InsertCategoryAsync(Category category)
    {
        try
        {
            await _appDBContext.Categories.AddAsync(category);
            await _appDBContext.SaveChangesAsync();
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
            return await _appDBContext.Categories.Include(c => c.User).FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while fetching category with ID {categoryId}.");
            throw;
        }
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        try
        {
            _appDBContext.Categories.Update(category);
            await _appDBContext.SaveChangesAsync();
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
            _appDBContext.Categories.Remove(category);
            await _appDBContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting category with ID {category.CategoryId}.");
            throw;
        }
    }
}
