using Microsoft.AspNetCore.Identity;

namespace AngulaToDo.Server.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IdentityResult> CreateUserAsync(string userName, string userEmail, string password);
    }
}
