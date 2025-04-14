using LocalExperience.AppServices.Interfaces.TripsInterestProfiles;
using LocalExperience.AppServices.Interfaces.TripsInterestProfiles.DTOs;
using LocalExperience.Domain.Trips;
using LocalExperience.Domain.Trips.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Trips
{
    public class TripsInterestProfileAppService : ITripsInterestProfileAppService
    {
        private readonly ITripsInterestProfileRepository _tripsInterestProfilerepository;

        public TripsInterestProfileAppService(ITripsInterestProfileRepository tripsInterestProfilerepository)
        {
            _tripsInterestProfilerepository = tripsInterestProfilerepository;
        }

        public async Task<TripsInterestProfileDto> GetByTripIdAsync(Guid tripId)
        {
            var tripsInterest = await _tripsInterestProfilerepository.GetByTripIdAsync(tripId);
            if (tripsInterest == null) throw new KeyNotFoundException("Interesses da viagem não foram encontrado.");

            return new TripsInterestProfileDto
            {
                TripId = tripsInterest.TripId,
                CultureInterest = (int)tripsInterest.CultureInterest,
                NatureInterest = (int)tripsInterest.NatureInterest,
                GastronomyInterest = (int)tripsInterest.GastronomyInterest,
                NightlifeInterest = (int)tripsInterest.NightlifeInterest,
                ShoppingInterest = (int)tripsInterest.ShoppingInterest
            };  
        }

        public async Task AddAsync(TripsInterestProfileCreateDto tripsInterest)
        {
            var tripsInterestProfile = new TripsInterestProfile
            {
                TripId = tripsInterest.TripId,
                CultureInterest = tripsInterest.CultureInterest,
                NatureInterest = tripsInterest.NatureInterest,
                GastronomyInterest = tripsInterest.GastronomyInterest,
                NightlifeInterest = tripsInterest.NightlifeInterest,
                ShoppingInterest = tripsInterest.ShoppingInterest
            };

            await _tripsInterestProfilerepository.AddAsync(tripsInterestProfile);
        }

        public async Task UpdateAsync(TripsInterestProfileUpdateDto tripsInterest)
        {
            var tripsInterestProfile = await _tripsInterestProfilerepository.GetByTripIdAsync(tripsInterest.TripId);
            if (tripsInterestProfile == null) throw new KeyNotFoundException("Interesses da viagem não foram encontrado.");

            tripsInterest.CultureInterest = tripsInterest.CultureInterest;
            tripsInterest.NatureInterest = tripsInterest.NatureInterest;
            tripsInterest.GastronomyInterest = tripsInterest.GastronomyInterest;
            tripsInterest.NightlifeInterest = tripsInterest.NightlifeInterest;
            tripsInterest.ShoppingInterest = tripsInterest.ShoppingInterest;

            await _tripsInterestProfilerepository.UpdateAsync(tripsInterestProfile);
        }

        public async Task DeleteAsync(Guid id)
        {
            var tripsInterestProfile = await _tripsInterestProfilerepository.GetByTripIdAsync(id);
            if (tripsInterestProfile == null) throw new KeyNotFoundException("Interesses da viagem não foram encontrado.");

            await _tripsInterestProfilerepository.DeleteAsync(id);
        }
    }
}
