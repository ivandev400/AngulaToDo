using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace AngulaToDo.Server.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IdentityResult> CreateUserAsync(UserForRegistrationDto userForRegistration);
        public string GenerateJwtToken(User user);
    }
}
