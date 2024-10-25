using AngulaToDo.Server.Data.Dtos;

namespace AngulaToDo.Server.Services.Interfaces
{
    public interface IFilterService
    {
        public Task<IEnumerable<TaskDto>> GetDailyTasksAsync(string userId);
        public Task<IEnumerable<TaskDto>> GetImportantTasksAsync(string userId);
        public Task<IEnumerable<TaskDto>> GetPlannedTasksAsync(string userId);
        public Task<IEnumerable<TaskDto>> GetCompletedTasksAsync(string userId);
    }
}
