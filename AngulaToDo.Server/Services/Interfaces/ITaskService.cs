using Task = AngulaToDo.Server.Models.Task;

namespace AngulaToDo.Server.Services.Interfaces
{
    public interface ITaskService
    {
        public Task<IEnumerable<Task>> GetAllTasksAsync(string userId);
    }
}
