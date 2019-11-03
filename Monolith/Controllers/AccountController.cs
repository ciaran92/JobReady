using Microsoft.AspNetCore.Mvc;
using Monolith.Domain.Context;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Models;

namespace Monolith.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AccountController(PrimarydbContext context, IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] SignupModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Incorrect details entered");
            }

            var response = _userService.SignupUser(model);

            if(response.Success)
            {
                return Ok(response);
            }
            
            return BadRequest(response);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var response = _userService.Login(model);

            if (response.Success)
            {
                response.JwtToken = _authService.NewJwtToken();
                return Ok(response);
            }
            
            return BadRequest(response);
        }
    }
}