using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using AngulaToDo.Server.Repositories.Interfaces;
using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Task = AngulaToDo.Server.Models.Task;

namespace AngulaToDo.Server.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly UserManager<User> _userManager;
        public TaskService(ITaskRepository taskRepository, UserManager<User> userManager)
        {
            _taskRepository = taskRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Task>> GetAllTasksAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            return await _taskRepository.GetAllAsync(userId);
        }

        public async Task<Task> CreateTaskAsync(string userId, TaskDto taskDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;

            return await _taskRepository.CreateTaskAsync(userId, taskDto);
        }

        public async Task<Task> GetTaskByIdAsync(string userId, int taskId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var task = await _taskRepository.GetTaskByIdAsync(userId, taskId);

            if (user == null)
                return null;

            return task;
        }

        public async Task<Task> UpdateTaskAsync(string userId, int taskId, TaskDto taskDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var task = await _taskRepository.UpdateTaskAsync(userId, taskId, taskDto);

            if (user == null)
                return null;

            return task;
        }

        public async Task<Task> DeleteTaskAsync(string userId, int taskId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var task = await _taskRepository.DeleteTaskAsync(userId, taskId);

            if (user == null)
                return null;

            return task;
        }
    }
}
