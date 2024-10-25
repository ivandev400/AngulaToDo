using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using AngulaToDo.Server.Repositories.Interfaces;
using AngulaToDo.Server.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AngulaToDo.Server.Services
{
    public class FilterService : IFilterService
    {
        private readonly IFilterRepository _filterRepository;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public FilterService(IFilterRepository filterRepository, UserManager<User> userManager, IMapper mapper)
        {
            _filterRepository = filterRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskDto>> GetDailyTasksAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            var tasks = await _filterRepository.GetDailyTasksAsync(userId);
            var taskDtos = tasks.Select(t => _mapper.Map<TaskDto>(t)).ToList();

            return taskDtos;
        }

        public async Task<IEnumerable<TaskDto>> GetImportantTasksAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            var tasks = await _filterRepository.GetImportantTasksAsync(userId);
            var taskDtos = tasks.Select(t => _mapper.Map<TaskDto>(t)).ToList();

            return taskDtos;
        }

        public async Task<IEnumerable<TaskDto>> GetPlannedTasksAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            var tasks = await _filterRepository.GetPlannedTasksAsync(userId);
            var taskDtos = tasks.Select(t => _mapper.Map<TaskDto>(t)).ToList();

            return taskDtos;
        }

        public async Task<IEnumerable<TaskDto>> GetCompletedTasksAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            var tasks = await _filterRepository.GetCompletedTasksAsync(userId);
            var taskDtos = tasks.Select(t => _mapper.Map<TaskDto>(t)).ToList();

            return taskDtos;
        }
    }
}
