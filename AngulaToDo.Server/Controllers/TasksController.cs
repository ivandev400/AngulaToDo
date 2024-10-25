using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AngulaToDo.Server.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : Controller
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
                return NotFound();

            return Ok(result);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> CreateTask(string userId, [FromBody] TaskDto taskDto)
        {
            var task = await _taskService.CreateTaskAsync(userId, taskDto);

            if (task == null)
                return NotFound();

            return Ok();
        }

        [HttpGet("{userId}/{taskId}")]
        public async Task<ActionResult> GetTaskById(string userId, int taskId)
        {
            var task = await _taskService.GetTaskByIdAsync(userId, taskId);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPut("{userId}/{taskId}")]
        public async Task<ActionResult> UpdateTask(string userId, int taskId, [FromBody] TaskDto taskDto)
        {
            var result = await _taskService.UpdateTaskAsync(userId, taskId, taskDto);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{userId}/{taskId}")]
        public async Task<IActionResult> DeleteTask(string userId, int taskId)
        {
            var result = await _taskService.DeleteTaskAsync(userId, taskId);

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("{userId}/category/{categoryName}")]
        public async Task<IActionResult> GetTasksByCategoryName(string userId, string categoryName)
        {
            var result = await _taskService.GetTasksByCategoryNameAsync(userId, categoryName);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
