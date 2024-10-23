using AngulaToDo.Server.Data;
using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using AngulaToDo.Server.Repositories.Interfaces;
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
        public TaskRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetAllAsync(string userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId)
                .ToListAsync();

            return tasks;
        }

        public async Task<Task> CreateTaskAsync(string userId, TaskDto taskDto)
        {
            var task = new Task
            {
                UserId = userId,
                Title = taskDto.Title,
                IsImportant = taskDto.IsImportant,
                Created = DateTime.Now,
                DueDate = taskDto.DueDate,
                CategoryId = taskDto.CategoryId
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<Task> GetTaskByIdAsync(string userId, int taskId)
        {
            var task = await _context.Tasks
                .FirstOrDefaultAsync(t => t.UserId == userId && t.Id == taskId);

            return task;
        }

        public async Task<Task> UpdateTaskAsync(string userId, int taskId, TaskDto taskDto)
        {
            var task = await GetTaskByIdAsync(userId, taskId);

            task.Title = taskDto.Title;
            task.IsImportant = taskDto.IsImportant;
            task.Completed = taskDto.Completed;
            task.DueDate = taskDto.DueDate;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<Task> DeleteTaskAsync(string userId, int taskId)
        {
            var task = await GetTaskByIdAsync(userId, taskId);

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }
    }
}
