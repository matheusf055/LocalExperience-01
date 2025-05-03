using LocalExperience.AppServices.Interfaces.TripsInterestProfiles;
using LocalExperience.AppServices.Interfaces.TripsInterestProfiles.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LocalExperience.Api.Controllers.TripsInterestProfiles
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsInterestProfileController : ControllerBase
    {
        private readonly ITripsInterestProfileAppService _tripsInterestProfileAppService;

        public TripsInterestProfileController(ITripsInterestProfileAppService tripsInterestProfileAppService)
        {
            _tripsInterestProfileAppService = tripsInterestProfileAppService;
        }

        [HttpGet("trip/{tripId}")]
        public async Task<ActionResult<TripsInterestProfileDto>> GetByTripId(Guid tripId)
        {
            var tripsInterestProfile = await _tripsInterestProfileAppService.GetByTripId(tripId);
            return Ok(tripsInterestProfile);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TripsInterestProfileCreateDto tripsInterestProfileDto)
        {
            await _tripsInterestProfileAppService.Create(tripsInterestProfileDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] TripsInterestProfileUpdateDto tripsInterestProfileDto)
        {
            await _tripsInterestProfileAppService.Update(tripsInterestProfileDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _tripsInterestProfileAppService.Delete(id);
            return NoContent();
        }
    }
} 