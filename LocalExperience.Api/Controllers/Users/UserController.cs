using LocalExperience.AppServices.Interfaces.Users;
using LocalExperience.AppServices.Users.Commands;
using LocalExperience.AppServices.Users.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LocalExperience.Api.Controllers.Users
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById([FromRoute] Guid id)
        {
            var user = await _userAppService.GetById(id);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand command)
        {
            await _userAppService.Update(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _userAppService.Delete(id);
            return NoContent();
        }
    }
}
