using LocalExperience.AppServices.Interfaces.Preferences;
using LocalExperience.AppServices.Preferences.Commands;
using LocalExperience.AppServices.Preferences.DTOs;
using LocalExperience.AppServices.Trips.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LocalExperience.Api.Controllers.Preferences
{
    [ApiController]
    [Route("api/preferences")]
    public class PreferencesController : ControllerBase
    {
        private readonly IPreferencesAppService _preferencesAppService;

        public PreferencesController(IPreferencesAppService preferencesAppService)
        {
            _preferencesAppService = preferencesAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PreferenceDto>> GetByTripId([FromRoute] Guid id)
        {
            var preference = await _preferencesAppService.GetByTripId(id);
            return Ok(preference);
        }

        [HttpPost]
        public async Task<ActionResult<PreferenceDto>> Create([FromBody] CreatePreferencesCommand command)
        {
            await _preferencesAppService.Create(command);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdatePreferencesCommand command)
        {
            await _preferencesAppService.Update(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _preferencesAppService.Delete(id);
            return NoContent();
        }
    }
}