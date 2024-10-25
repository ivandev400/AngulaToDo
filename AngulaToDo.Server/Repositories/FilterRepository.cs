using AngulaToDo.Server.Data;
using AngulaToDo.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = AngulaToDo.Server.Models.Task;

namespace AngulaToDo.Server.Repositories
{
    public class FilterRepository : IFilterRepository
    {
        private readonly ToDoContext _context;
        public FilterRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task>> GetDailyTasksAsync(string userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId && t.Completed == false)
                .Where(t => t.DueDate.Date == DateTime.Now.Date)
                .AsNoTracking()
                .ToListAsync();

            return tasks;
        }

        public async Task<IEnumerable<Task>> GetImportantTasksAsync(string userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId && t.Completed == false)
                .Where(t => t.IsImportant == true)
                .AsNoTracking()
                .ToListAsync();

            return tasks;
        }

        public async Task<IEnumerable<Task>> GetPlannedTasksAsync(string userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId && t.Completed == false)
                .Where(t => t.DueDate.Date != DateTime.Now.Date && t.DueDate.Date !< DateTime.Now.Date)
                .AsNoTracking()
                .ToListAsync();

            return tasks;
        }

        public async Task<IEnumerable<Task>> GetCompletedTasksAsync(string userId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.UserId == userId && t.Completed == true)
                .Where(t => t.Completed == true)
                .AsNoTracking()
                .ToListAsync();

            return tasks;
        }
    }
}
