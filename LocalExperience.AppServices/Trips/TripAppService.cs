using LocalExperience.AppServices.Interfaces.Trips;
using LocalExperience.AppServices.Interfaces.Trips.DTOs;
using LocalExperience.AppServices.Mappers.Trips;
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

        public async Task<TripDto> GetByIdAsync(Guid id)
        {
            var trip = await _tripRepository.GetByIdAsync(id);
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

        public async Task<TripDto> GetByIdWithDetailsAsync(Guid id)
        {
            var trip = await _tripRepository.GetByIdAsync(id);
            if (trip == null) throw new KeyNotFoundException("Viagem não foi encontrada.");

            return TripMapper.ConvertTripWithDetails(trip);
        }

        public async Task<TripDto> GetByShareCodeAsync(string shareCode)
        {
            var trip = await _tripRepository.GetByShareCodeAsync(shareCode);
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

        public async Task<List<TripDto>> GetUserTripsAsync(Guid userId)
        {
            var trips = await _tripRepository.GetUserTripsAsync(userId);

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

        public async Task AddAsync(CreateTripDto tripDto)
        {
            var trip = new Trip(
                tripDto.UserId,
                tripDto.Destination,
                tripDto.StartDate,
                tripDto.EndDate,
                tripDto.ShareCode
            );

            await _tripRepository.AddAsync(trip);
        }

        public async Task UpdateAsync(UpdateTripDto tripDto)
        {
            var trip = await _tripRepository.GetByIdAsync(tripDto.Id);
            if (trip == null) throw new KeyNotFoundException("Viagem não foi encontrada.");

            trip.Destination = tripDto.Destination;
            trip.StartDate = tripDto.StartDate;
            trip.EndDate = tripDto.EndDate;
            trip.ShareCode = tripDto.ShareCode;

            trip.TripsInterestProfile.CultureInterest = tripDto.InterestProfile.CultureInterest;
            trip.TripsInterestProfile.NatureInterest = tripDto.InterestProfile.NatureInterest;
            trip.TripsInterestProfile.ShoppingInterest = tripDto.InterestProfile.ShoppingInterest;
            trip.TripsInterestProfile.GastronomyInterest = tripDto.InterestProfile.GastronomyInterest;
            trip.TripsInterestProfile.NightlifeInterest = tripDto.InterestProfile.NightlifeInterest;

            await _tripRepository.UpdateAsync(trip);
        }

        public async Task DeleteAsync(Guid id)
        {
            var trip = await _tripRepository.GetByIdAsync(id);
            if (trip == null) throw new KeyNotFoundException("Viagem não foi encontrada.");

            await _tripRepository.DeleteAsync(id);
        }
    }
}
