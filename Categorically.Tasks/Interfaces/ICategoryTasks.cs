using Categorically.DataAccess.Models;

namespace Categorically.Tasks;

public interface ICategoryTasks
{
    Task DeleteCategoryAsync(Category category);
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryAsync(int categoryId);
    Task InsertCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
}