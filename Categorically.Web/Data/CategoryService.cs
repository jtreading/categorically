using Microsoft.EntityFrameworkCore;
using Categorically.DataAccess;
using Categorically.Services.Models;

namespace Categorically.Data
{
    public class CategoryService
    {
        #region Properties
        private readonly AppDBContext _appDBContext;
        #endregion

        #region Constructor
        public CategoryService(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Categories
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _appDBContext.Categories.Include(c => c.User).ToListAsync();
        }
        #endregion

        #region Insert Category
        public async Task<bool> InsertCategoryAsync(Category category)
        {
            await _appDBContext.Categories.AddAsync(category);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Category by Id
        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _appDBContext.Categories.Include(c => c.User).FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }
        #endregion

        #region Update Category
        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            _appDBContext.Categories.Update(category);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Category
        public async Task<bool> DeleteCategoryAsync(Category category)
        {
            _appDBContext.Categories.Remove(category);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
