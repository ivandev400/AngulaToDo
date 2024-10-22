using AngulaToDo.Server.Data;
using AngulaToDo.Server.Data.Dtos;
using AngulaToDo.Server.Models;
using AngulaToDo.Server.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngulaToDo.Server.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly IRegisterService _userService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountsController(IRegisterService userService, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var result = await _userService.CreateUserAsync(userForRegistration);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userForLogin.Email, userForLogin.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(userForLogin.Email);

                return Ok(new {userId = user.Id});
            }

            return Unauthorized();
        }
    }
}
