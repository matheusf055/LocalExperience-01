using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalExperience.AppServices.Interfaces.Itineraries.DTOs;

namespace LocalExperience.AppServices.Interfaces.Itineraries
{
    public interface IItineraryAppService
    {
        Task<ItineraryDto> GetByIdAsync(Guid id);
        Task AddAsync(CreateItineraryDto itineraryDto);
        Task UpdateAsync(UpdateItineraryDto itineraryDto);
        Task DeleteAsync(Guid id);
    }
}
