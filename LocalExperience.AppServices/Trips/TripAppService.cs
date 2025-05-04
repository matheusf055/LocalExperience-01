using LocalExperience.AppServices.Interfaces.Trips;
using LocalExperience.AppServices.Trips.DTOs;
using LocalExperience.Domain.Trips;
using LocalExperience.Domain.Trips.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Trips
{
    public class TripAppService : ITripAppService
    {
        private readonly ITripRepository _tripRepository;

        public TripAppService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<TripDto> GetById(Guid id)
        {
            var trip = await _tripRepository.GetById(id);
            if (trip == null) throw new KeyNotFoundException("Viagem não foi encontrada.");

            return new TripDto
            {
                Id = trip.Id,
                UserId = trip.UserId,
                Destination = trip.Destination,
                ShareCode = trip.ShareCode,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                CreateDate = trip.CreateDate,
            };
        }

        public async Task<TripDto> GetByShareCode(string shareCode)
        {
            var trip = await _tripRepository.GetByShareCode(shareCode);
            if (trip == null) throw new KeyNotFoundException("Viagem não foi encontrada.");

            return new TripDto
            {
                Id = trip.Id,
                UserId = trip.UserId,
                Destination = trip.Destination,
                ShareCode = trip.ShareCode,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                CreateDate = trip.CreateDate,
            };
        }

        public async Task<List<TripDto>> GetAll(Guid userId)
        {
            var trips = await _tripRepository.GetAll(userId);

            if (trips == null || trips.Any() == false)
                return new List<TripDto>();

            var tripDtos = trips.Select(trips => new TripDto
            {
                Id = trips.Id,
                UserId = trips.UserId,
                Destination = trips.Destination,
                ShareCode = trips.ShareCode,
                StartDate = trips.StartDate,
                EndDate = trips.EndDate,
                CreateDate = trips.CreateDate,
            }).ToList();

            return tripDtos;
        }

        public async Task Create(CreateTripDto tripDto)
        {
            var trip = new Trip(
                tripDto.UserId,
                tripDto.Destination,
                tripDto.StartDate,
                tripDto.EndDate
            );

            await _tripRepository.Create(trip);
        }

        public async Task Update(UpdateTripDto tripDto)
        {
            var trip = await _tripRepository.GetById(tripDto.Id);
            if (trip == null) throw new KeyNotFoundException("Viagem não foi encontrada.");

            trip.Destination = tripDto.Destination;
            trip.StartDate = tripDto.StartDate;
            trip.EndDate = tripDto.EndDate;

            await _tripRepository.Update(trip);
        }

        public async Task Delete(Guid id)
        {
            var trip = await _tripRepository.GetById(id);
            if (trip == null) throw new KeyNotFoundException("Viagem não foi encontrada.");

            await _tripRepository.Delete(id);
        }
    }
}
