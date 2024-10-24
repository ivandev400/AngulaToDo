using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using AngulaToDo.Server.Repositories.Interfaces;
using AngulaToDo.Server.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Task = AngulaToDo.Server.Models.Task;

namespace AngulaToDo.Server.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, UserManager<User> userManager, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            var tasks = await _taskRepository.GetAllAsync(userId);
            var taskDtos = tasks.Select(t => _mapper.Map<TaskDto>(t)).ToList();

            return taskDtos;
        }

        public async Task<Task> CreateTaskAsync(string userId, TaskDto taskDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return null;
            var task = _mapper.Map<Task>(taskDto);

            return await _taskRepository.CreateTaskAsync(userId, task);
        }

        public async Task<Task> GetTaskByIdAsync(string userId, int taskId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var task = await _taskRepository.GetTaskByIdAsync(userId, taskId);

            if (user == null)
                return null;

            return task;
        }

        public async Task<bool> UpdateTaskAsync(string userId, int taskId, TaskDto taskDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var task = await _taskRepository.UpdateTaskAsync(userId, taskId, taskDto);

            if (user == null)
                return false;

            return true;
        }

        public async Task<bool> DeleteTaskAsync(string userId, int taskId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _taskRepository.DeleteTaskAsync(userId, taskId);

            if (user == null)
                return false;

            return true;
        }
    }
}
