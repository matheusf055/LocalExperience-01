using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.Domain.Trips.Repositories
{
    public interface ITripsInterestProfileRepository
    {
        Task<TripsInterestProfile> GetByTripId(Guid tripId);
        Task Create(TripsInterestProfile profile);
        Task Update(TripsInterestProfile profile);
        Task Delete(Guid id);
    }

}
