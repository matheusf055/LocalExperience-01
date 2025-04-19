using LocalExperience.AppServices.Interfaces.Trips;
using LocalExperience.AppServices.Interfaces.Trips.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalExperience.Api.Controllers.Trips
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ITripAppService _tripAppService;

        public TripController(ITripAppService tripAppService)
        {
            _tripAppService = tripAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TripDto>> GetById(Guid id)
        {
            var trip = await _tripAppService.GetByIdAsync(id);
            return Ok(trip);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<TripDto>> GetByIdWithDetails(Guid id)
        {
            var trip = await _tripAppService.GetByIdWithDetailsAsync(id);
            return Ok(trip);
        }

        [HttpGet("share/{shareCode}")]
        public async Task<ActionResult<TripDto>> GetByShareCode(string shareCode)
        {
            var trip = await _tripAppService.GetByShareCodeAsync(shareCode);
            return Ok(trip);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<TripDto>>> GetUserTrips(Guid userId)
        {
            var trips = await _tripAppService.GetUserTripsAsync(userId);
            return Ok(trips);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateTripDto tripDto)
        {
            await _tripAppService.AddAsync(tripDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateTripDto tripDto)
        {
            await _tripAppService.UpdateAsync(tripDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _tripAppService.DeleteAsync(id);
            return NoContent();
        }
    }
} 