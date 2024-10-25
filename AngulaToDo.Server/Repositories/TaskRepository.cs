using AngulaToDo.Server.Data;
using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using AngulaToDo.Server.Repositories.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Diagnostics;
using Task = AngulaToDo.Server.Models.Task;

namespace AngulaToDo.Server.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoContext _context;
        private readonly IMapper _mapper;
        public TaskRepository(ToDoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Task>> GetAllAsync(string userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId)
                .AsNoTracking()
                .ToListAsync();

            return tasks;
        }

        public async Task<IEnumerable<Task>> GetByCategoryNameAsync(string userId, string categoryName)
        {
            var category = _context.Categories
                .AsNoTracking()
                .FirstOrDefault(c => c.Name == categoryName && c.UserId == userId);

            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId && t.CategoryId == category.Id)
                .AsNoTracking()
                .ToListAsync();

            return tasks;
        }

        public async Task<Task> CreateTaskAsync(string userId, Task task)
        {
            task.UserId = userId;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<Task> GetTaskByIdAsync(string userId, int taskId)
        {
            var task = await _context.Tasks
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId);

            return task;
        }

        public async Task<bool> UpdateTaskAsync(string userId, int taskId, TaskDto taskDto)
        {
            var task = await GetTaskByIdAsync(userId, taskId);

            if (task == null)
                return false;
            task = _mapper.Map(taskDto, task);

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTaskAsync(string userId, int taskId)
        {
            var task = await GetTaskByIdAsync(userId, taskId);

            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
