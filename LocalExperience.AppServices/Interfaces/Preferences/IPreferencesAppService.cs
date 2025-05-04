using LocalExperience.AppServices.Preferences.Commands;
using LocalExperience.AppServices.Preferences.DTOs;
using LocalExperience.AppServices.Trips.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Interfaces.Preferences
{
    public interface IPreferencesAppService
    {
        Task<PreferenceDto> GetByTripId(Guid tripId);
        Task<PreferenceDto> Create(CreatePreferencesCommand command);
        Task Update(UpdatePreferencesCommand command);
        Task Delete(Guid id);
    }
}
