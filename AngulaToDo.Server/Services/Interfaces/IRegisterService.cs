using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using Microsoft.AspNetCore.Identity;

namespace AngulaToDo.Server.Services.Interfaces
{
    public interface IRegisterService
    {
        public Task<IdentityResult> CreateUserAsync(UserForRegistrationDto userForRegistration);
    }
}
