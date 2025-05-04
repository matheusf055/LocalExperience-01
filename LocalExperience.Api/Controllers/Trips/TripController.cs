using LocalExperience.AppServices.Interfaces.Trips;
using LocalExperience.AppServices.Trips.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalExperience.Api.Controllers.Trips
{
    [ApiController]
    [Route("api/trips")]
    public class TripController : ControllerBase
    {
        private readonly ITripAppService _tripAppService;

        public TripController(ITripAppService tripAppService)
        {
            _tripAppService = tripAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TripDto>> GetById([FromRoute] Guid id)
        {
            var trip = await _tripAppService.GetById(id);
            return Ok(trip);
        }

        [HttpGet("share/{shareCode}")]
        public async Task<ActionResult<TripDto>> GetByShareCode(string shareCode)
        {
            var trip = await _tripAppService.GetByShareCode(shareCode);
            return Ok(trip);
        }

        [HttpGet]
        public async Task<ActionResult<List<TripDto>>> GetAll(Guid id)
        {
            var trips = await _tripAppService.GetAll(id);
            return Ok(trips);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateTripDto tripDto)
        {
            await _tripAppService.Create(tripDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTripDto tripDto)
        {
            await _tripAppService.Update(tripDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _tripAppService.Delete(id);
            return NoContent();
        }
    }
} 