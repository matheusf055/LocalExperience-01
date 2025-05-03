using LocalExperience.AppServices.Interfaces.TripsInterestProfiles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalExperience.AppServices.Interfaces.TripsInterestProfiles
{
    public interface ITripsInterestProfileAppService
    {
        Task<TripsInterestProfileDto> GetByTripId(Guid tripId);
        Task Create(TripsInterestProfileCreateDto profile);
        Task Update(TripsInterestProfileUpdateDto profile);
        Task Delete(Guid id);
    }
}
