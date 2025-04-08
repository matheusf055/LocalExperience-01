using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Trips.Repositories
{
    public interface ITripsInterestProfileRepository
    {
        Task<TripsInterestProfile> GetByTripIdAsync(Guid tripId);
        Task AddAsync(TripsInterestProfile profile);
        Task UpdateAsync(TripsInterestProfile profile);
        Task DeleteAsync(Guid id);
    }

}
