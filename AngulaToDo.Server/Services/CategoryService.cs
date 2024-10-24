using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using AngulaToDo.Server.Repositories.Interfaces;
using AngulaToDo.Server.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AngulaToDo.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, UserManager<User> userManager, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            var categories = await _categoryRepository.GetAllCategoriesAsync(userId);
            var categoryDtos = categories.Select(c => _mapper.Map<CategoryDto>(c)).ToList();
            return categoryDtos;
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

            var category = _mapper.Map<Category>(categoryDto);
            return await _categoryRepository.CreateCategoryAsync(userId, category); 
        }

        public async Task<bool> DeleteCategoryAsync(string userId, int categoryId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return false;

            var result = await _categoryRepository.DeleteCategoryAsync(userId, categoryId);
            return result;
        }
    }
}
