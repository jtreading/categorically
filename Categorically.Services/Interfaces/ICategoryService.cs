using Categorically.DataAccess.Models;

namespace Categorically.Services;
public interface ICategoryService
{
    void DeleteCategoryAsync(Category category);
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryAsync(int categoryId);
    void InsertCategoryAsync(Category category);
    void UpdateCategoryAsync(Category category);
}