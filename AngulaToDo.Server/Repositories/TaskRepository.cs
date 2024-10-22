using AngulaToDo.Server.Data;
using AngulaToDo.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    }
}
