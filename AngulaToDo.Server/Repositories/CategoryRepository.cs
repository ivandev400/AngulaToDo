﻿using AngulaToDo.Server.Data;
using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using AngulaToDo.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngulaToDo.Server.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ToDoContext _context;
        public CategoryRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(string userId)
        {
            var categories = await _context.Categories
                .Where(c => c.UserId == userId)
                .ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryByNameAsync(string userId, string name)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == name && c.UserId == userId);

            return category;
        }

        public async Task<Category> CreateCategoryAsync(string userId, CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                UserId = userId
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> DeleteCategoryAsync(string userId, int categoryId)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId &&  c.UserId == userId);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}