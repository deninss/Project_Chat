using API.Model;
using API.Services.loginServices;
using API.Services.registerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;

        public AuthController(IRegisterService authService, ILoginService loginService)
        {
            _registerService = authService;
            _loginService = loginService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUser user)
        {
            if (await _registerService.RegisterUser(user))
            {
                return Ok(true);
            } 
            return BadRequest("Something went wrong");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        { 
            if (await _loginService.Login(user))
            {
                var tokenString = _loginService.GenerateTokenString(user);
                return Ok(new { token = tokenString, success = true });
            }
            return BadRequest();
        }
    }
}
