using LocalExperience.AppServices.Interfaces.Preferences;
using LocalExperience.AppServices.Preferences.Commands;
using LocalExperience.AppServices.Preferences.DTOs;
using LocalExperience.AppServices.Trips.DTOs;
using LocalExperience.Domain.Preferences;
using LocalExperience.Domain.Preferences.Repositories;
using LocalExperience.Domain.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Preferences
{
    public class PreferencesAppService : IPreferencesAppService
    {
        private readonly IPreferencesRepository _preferenceRepository;

        public PreferencesAppService(IPreferencesRepository preferencesRepository)
        {
            _preferenceRepository = preferencesRepository;
        }

        public async Task<PreferenceDto> GetByTripId(Guid tripId)
        {
            var preferences = await _preferenceRepository.GetByTripId(tripId);
            if (preferences == null) throw new KeyNotFoundException("Interesses da viagem não foram encontrado.");

            return new PreferenceDto
            {
                TripId = preferences.TripId,
                CultureInterest = preferences.CultureInterest,
                NatureInterest = preferences.NatureInterest,
                GastronomyInterest = preferences.GastronomyInterest,
                NightlifeInterest = preferences.NightlifeInterest,
                ShoppingInterest = preferences.ShoppingInterest
            };
        }

        public async Task<PreferenceDto> Create(CreatePreferencesCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var preference = new Preference
            {
                TripId = command.TripId,
                CultureInterest = command.CultureInterest,
                NatureInterest = command.NatureInterest,
                GastronomyInterest = command.GastronomyInterest,
                NightlifeInterest = command.NightlifeInterest,
                ShoppingInterest = command.ShoppingInterest
            };

            await _preferenceRepository.Create(preference);

            return new PreferenceDto
            {
                TripId = preference.TripId,
                CultureInterest = preference.CultureInterest,
                NatureInterest = preference.NatureInterest,
                GastronomyInterest = preference.GastronomyInterest,
                NightlifeInterest = preference.NightlifeInterest,
                ShoppingInterest = preference.ShoppingInterest
            };
        }

        public async Task Update(UpdatePreferencesCommand command)
        {
            var preference = await _preferenceRepository.GetByTripId(command.TripId);
            if (preference == null) throw new KeyNotFoundException("Interesses da viagem não foram encontrado.");

            preference.CultureInterest = command.CultureInterest;
            preference.NatureInterest = command.NatureInterest;
            preference.GastronomyInterest = command.GastronomyInterest;
            preference.NightlifeInterest = command.NightlifeInterest;
            preference.ShoppingInterest = command.ShoppingInterest;

            await _preferenceRepository.Update(preference);
        }

        public async Task Delete(Guid id)
        {
            var preference = await _preferenceRepository.GetByTripId(id);
            if (preference == null) throw new KeyNotFoundException("Interesses da viagem não foram encontrado.");

            await _preferenceRepository.Delete(id);
        }
    }
}
