using AngulaToDo.Server.Models;
using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace AngulaToDo.Server.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(string userName, string userEmail, string password)
        {
            var user = new User
            {
                UserName = userName,
                Email = userEmail,
            };

            return await _userManager.CreateAsync(user, password);
        }
    }
}
