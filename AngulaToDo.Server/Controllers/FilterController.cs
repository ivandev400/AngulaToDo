using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AngulaToDo.Server.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    [Route("api/filter")]
    public class FilterController : Controller
    {
        private readonly IFilterService _filterService;

        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet("{userId}/daily")]
        public async Task<ActionResult> GetDailyTasks(string userId)
        {
            var dailyTasks = await _filterService.GetDailyTasksAsync(userId);

            if (dailyTasks == null)
            {
                return NotFound();
            }

            return Ok(dailyTasks);
        }

        [HttpGet("{userId}/important")]
        public async Task<ActionResult> GetImportantTasks(string userId)
        {
            var importantTasks = await _filterService.GetImportantTasksAsync(userId);

            if (importantTasks == null)
            {
                return NotFound();
            }

            return Ok(importantTasks);
        }

        [HttpGet("{userId}/planned")]
        public async Task<ActionResult> GetPlannedTasks(string userId)
        {
            var plannedTasks = await _filterService.GetPlannedTasksAsync(userId);

            if (plannedTasks == null)
            {
                return NotFound();
            }

            return Ok(plannedTasks);
        }

        [HttpGet("{userId}/completed")]
        public async Task<ActionResult> GetCompletedTasks(string userId)
        {
            var completedTasks = await _filterService.GetCompletedTasksAsync(userId);

            if (completedTasks == null)
            {
                return NotFound();
            }

            return Ok(completedTasks);
        }
    }
}
