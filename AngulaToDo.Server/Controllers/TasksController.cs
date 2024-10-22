using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AngulaToDo.Server.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetAllTasks(string userId)
        {
            var result = await _taskService.GetAllTasksAsync(userId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
