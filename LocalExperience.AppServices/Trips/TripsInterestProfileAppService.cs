using LocalExperience.AppServices.Interfaces.TripsInterestProfiles;
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
    public class TripsInterestProfileAppService : ITripsInterestProfileAppService
    {
        private readonly ITripsInterestProfileRepository _tripsInterestProfilerepository;

        public TripsInterestProfileAppService(ITripsInterestProfileRepository tripsInterestProfilerepository)
        {
            _tripsInterestProfilerepository = tripsInterestProfilerepository;
        }

        public async Task<TripsInterestProfileDto> GetByTripId(Guid tripId)
        {
            var tripsInterest = await _tripsInterestProfilerepository.GetByTripId(tripId);
            if (tripsInterest == null) throw new KeyNotFoundException("Interesses da viagem não foram encontrado.");

            return new TripsInterestProfileDto
            {
                TripId = tripsInterest.TripId,
                CultureInterest = tripsInterest.CultureInterest,
                NatureInterest = tripsInterest.NatureInterest,
                GastronomyInterest = tripsInterest.GastronomyInterest,
                NightlifeInterest = tripsInterest.NightlifeInterest,
                ShoppingInterest = tripsInterest.ShoppingInterest
            };  
        }

        public async Task Create(TripsInterestProfileCreateDto tripsInterest)
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

            await _tripsInterestProfilerepository.Create(tripsInterestProfile);
        }

        public async Task Update(TripsInterestProfileUpdateDto tripsInterest)
        {
            var tripsInterestProfile = await _tripsInterestProfilerepository.GetByTripId(tripsInterest.TripId);
            if (tripsInterestProfile == null) throw new KeyNotFoundException("Interesses da viagem não foram encontrado.");

            tripsInterest.CultureInterest = tripsInterest.CultureInterest;
            tripsInterest.NatureInterest = tripsInterest.NatureInterest;
            tripsInterest.GastronomyInterest = tripsInterest.GastronomyInterest;
            tripsInterest.NightlifeInterest = tripsInterest.NightlifeInterest;
            tripsInterest.ShoppingInterest = tripsInterest.ShoppingInterest;

            await _tripsInterestProfilerepository.Update(tripsInterestProfile);
        }

        public async Task Delete(Guid id)
        {
            var tripsInterestProfile = await _tripsInterestProfilerepository.GetByTripId(id);
            if (tripsInterestProfile == null) throw new KeyNotFoundException("Interesses da viagem não foram encontrado.");

            await _tripsInterestProfilerepository.Delete(id);
        }
    }
}
