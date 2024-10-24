using AngulaToDo.Server.Data.Dtos;
using Task = AngulaToDo.Server.Models.Task;

namespace AngulaToDo.Server.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<IEnumerable<TaskDto>> GetAllTasksAsync(string userId);
        public Task<Task> CreateTaskAsync(string userId, TaskDto taskDto);
        public Task<Task> GetTaskByIdAsync(string userId, int taskId);
        public Task<bool> UpdateTaskAsync(string userId, int taskIdl, TaskDto taskDto);
        public Task<bool> DeleteTaskAsync(string userId, int taskId);
    }
}
