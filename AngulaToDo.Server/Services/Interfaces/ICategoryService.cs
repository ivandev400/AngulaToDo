using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;

namespace AngulaToDo.Server.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(string userId);
        public Task<Category> GetCategoryByNameAsync(string userId, string name);
        public Task<Category> CreateCategoryAsync(string userId, CategoryDto category);
        public Task<bool> DeleteCategoryAsync(string userId, int categoryId);
    }
}
