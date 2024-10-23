using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using AngulaToDo.Server.Repositories.Interfaces;
using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AngulaToDo.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<User> _userManager;
        public CategoryService(ICategoryRepository categoryRepository, UserManager<User> userManager)
        {
            _categoryRepository = categoryRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            var category = await _categoryRepository.GetAllCategoriesAsync(userId);
            return category;
        }

        public async Task<Category> GetCategoryByNameAsync(string userId, string name)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            var category = await _categoryRepository.GetCategoryByNameAsync(userId, name);
            return category;
        }

        public async Task<Category> CreateCategoryAsync(string userId, CategoryDto categoryDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            var category = await _categoryRepository.CreateCategoryAsync(userId, categoryDto);
            return category;
        }

        public async Task<Category> DeleteCategoryAsync(string userId, int categoryId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            var category = await _categoryRepository.DeleteCategoryAsync(userId, categoryId);
            return category;
        }
    }
}
