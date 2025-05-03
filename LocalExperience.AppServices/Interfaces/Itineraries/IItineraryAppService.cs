using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalExperience.AppServices.Itineraries.DTOs;

namespace LocalExperience.AppServices.Interfaces.Itineraries
{
    public interface IItineraryAppService
    {
        Task<ItineraryDto> GetById(Guid id);
        Task Create(CreateItineraryDto itineraryDto);
        Task Update(UpdateItineraryDto itineraryDto);
        Task Delete(Guid id);
    }
}
