using Categorically.DataAccess.Models;

namespace Categorically.Services;
public interface ICategoryService
{
    Task DeleteCategoryAsync(Category category);
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryAsync(int categoryId);
    Task InsertCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
}