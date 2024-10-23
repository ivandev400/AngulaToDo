using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;

namespace AngulaToDo.Server.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync(string userId);
        public Task<Category> GetCategoryByNameAsync(string userId, string name);
        public Task<Category> CreateCategoryAsync(string userId, CategoryDto categoryDto);
        public Task<Category> DeleteCategoryAsync(string userId, int categoryId);
    }
}
