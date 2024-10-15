using AngulaToDo.Server.Models;
using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngulaToDo.Server.Controllers
{
    public class LoginController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class RegistrationController : ControllerBase
        {
            private readonly SignInManager<User> _signInManager;
            private readonly UserManager<User> _userManager;
            private readonly IUserService _userService;

            public RegistrationController(SignInManager<User> signInManager, IUserService userService, UserManager<User> userManager)
            {
                _signInManager = signInManager;
                _userService = userService;
                _userManager = userManager;
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginViewModel model)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);
                    var token = _userService.GenerateJwtToken(user);
                    return Ok(new { Token = token });
                }

                return Unauthorized();
            }
        }
    }
}
