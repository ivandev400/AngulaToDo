using AngulaToDo.Server.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using Task = AngulaToDo.Server.Models.Task;

namespace AngulaToDo.Server.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<Task>> GetAllAsync(string userId);
        public Task<Task> CreateTaskAsync(string userId, TaskDto taskDto);
        public Task<Task> GetTaskByIdAsync(string userId, int taskId);
        public Task<Task> UpdateTaskAsync(string userId, int taskId, TaskDto taskDto);
        public Task<Task> DeleteTaskAsync(string userId, int taskId);
    }
}
