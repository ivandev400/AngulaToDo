using Task = AngulaToDo.Server.Models.Task;

namespace AngulaToDo.Server.Repositories.Interfaces
{
    public interface IFilterRepository
    {
        public Task<IEnumerable<Task>> GetDailyTasksAsync(string userId);
        public Task<IEnumerable<Task>> GetImportantTasksAsync(string userId);
        public Task<IEnumerable<Task>> GetPlannedTasksAsync(string userId);
        public Task<IEnumerable<Task>> GetCompletedTasksAsync(string userId);
    }
}
