using AngulaToDo.Server.Models;
using AngulaToDo.Server.Repositories.Interfaces;
using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
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
    }
}
