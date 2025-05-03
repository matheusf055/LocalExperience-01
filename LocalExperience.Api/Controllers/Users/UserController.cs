using LocalExperience.AppServices.Interfaces.Users;
using LocalExperience.AppServices.Interfaces.Users.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LocalExperience.Api.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            var user = await _userAppService.GetById(id);
            return Ok(user);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<UserWithTripsDto>> GetByIdWithDetails(Guid id)
        {
            var user = await _userAppService.GetByIdWithDetails(id);
            return Ok(user);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Create([FromBody] UserRegisterDto userDto)
        {
            await _userAppService.Create(userDto);
            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _userAppService.Login(loginDto);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserUpdateDto userUpdateDto)
        {
            await _userAppService.Update(userUpdateDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _userAppService.Delete(id);
            return NoContent();
        }
    }
}
