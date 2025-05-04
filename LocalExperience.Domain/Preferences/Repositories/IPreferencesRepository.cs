using LocalExperience.Domain.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Preferences.Repositories
{
    public interface IPreferencesRepository
    {
        Task<Preference> GetByTripId(Guid tripId);
        Task Create(Preference profile);
        Task Update(Preference profile);
        Task Delete(Guid id);
    }

}
