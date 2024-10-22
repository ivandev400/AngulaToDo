using Task = AngulaToDo.Server.Models.Task;

namespace AngulaToDo.Server.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<Task>> GetAllAsync(string userId);
    }
}
