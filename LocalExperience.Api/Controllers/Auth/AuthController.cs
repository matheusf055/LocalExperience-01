using LocalExperience.AppServices.Auth.Commands;
using LocalExperience.AppServices.Auth.DTOs;
using LocalExperience.AppServices.Interfaces.Auth;
using LocalExperience.AppServices.Users.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LocalExperience.Api.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] RegisterUserCommand command)
        {
            await _authAppService.Register(command);
            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthDto>> Login([FromBody] LoginUserCommand command)
        {
            var auth = await _authAppService.Login(command);
            return Ok(auth);
        }
    }
}
