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
        Task<TripsInterestProfileDto> GetByTripIdAsync(Guid tripId);
        Task AddAsync(TripsInterestProfileCreateDto profile);
        Task UpdateAsync(TripsInterestProfileUpdateDto profile);
        Task DeleteAsync(Guid id);
    }
}
