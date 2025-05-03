using LocalExperience.AppServices.Interfaces.Itineraries;
using LocalExperience.AppServices.Interfaces.Itineraries.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LocalExperience.Api.Controllers.Itineraries
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryAppService _itineraryAppService;

        public ItineraryController(IItineraryAppService itineraryAppService)
        {
            _itineraryAppService = itineraryAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItineraryDto>> GetById(Guid id)
        {
            var itinerary = await _itineraryAppService.GetById(id);
            return Ok(itinerary);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateItineraryDto itineraryDto)
        {
            await _itineraryAppService.Create(itineraryDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateItineraryDto itineraryDto)
        {
            await _itineraryAppService.Update(itineraryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _itineraryAppService.Delete(id);
            return NoContent();
        }
    }
} 